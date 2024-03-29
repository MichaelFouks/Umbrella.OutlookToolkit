﻿using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mail;

namespace Umbrella.OutlookToolkit
{
    public class OutlookStoreProvider : IStoreProvider
    {
        private readonly string? storeName;

        public static IEnumerable<string> GetAvailableOutlookStores()
        {
            Application application = new Application();
            NameSpace outlookNamespaces = application.GetNamespace("MAPI");

            // Login using default profile
            outlookNamespaces.Logon(application.DefaultProfileName);

            List<string> result = new();

            foreach (Store store in outlookNamespaces.Stores)
            {
                result.Add(store.DisplayName);
            }

            return result;
        }

        private OutlookStoreProvider() { }

        public OutlookStoreProvider(string storeNameIn)
        {
            if (string.IsNullOrEmpty(storeNameIn))
            {
                throw new ArgumentException($"'{nameof(storeNameIn)}' cannot be null or empty.", nameof(storeNameIn));
            }

            storeName = storeNameIn;
        }

        public IEnumerable<MailItem> GetMailItems()
        {
            Application application = new Application();
            NameSpace outlookNamespaces = application.GetNamespace("MAPI");

            // Login using default profile
            outlookNamespaces.Logon(application.DefaultProfileName);

            Store store = outlookNamespaces.Stores[storeName];
            MAPIFolder rootFolder = store.GetRootFolder();

#if DEBUG
            foreach (Folder folder in rootFolder.Folders) 
            {
                Debug.WriteLine($"Folder Name: {folder.Name}; folder Entry ID: {folder.EntryID}; folder path: {folder.FullFolderPath}");
            }
#endif

            MAPIFolder inboxFolder = rootFolder.Folders["Inbox"];

            List<MailItem> result = new();
            foreach (var item in inboxFolder.Items)
            {
                if (item is MailItem mailItem)
                {
                    result.Add(mailItem);
                }
            }

            return result;
        }

        public StoreFolder GetStoreFolders()
        {
            Application application = new Application();
            NameSpace outlookNamespaces = application.GetNamespace("MAPI");

            // Login using default profile
            outlookNamespaces.Logon(application.DefaultProfileName);

            Store store = outlookNamespaces.Stores[storeName];
            MAPIFolder rootFolder = store.GetRootFolder();

            StoreFolder rootFolderModel = new StoreFolder()
            {
                Name = rootFolder.Name,
                FullPath = rootFolder.FullFolderPath,
                EntryId = rootFolder.EntryID,
                ParentFolder = null
            };

            foreach(MAPIFolder childFolder in rootFolder.Folders)
            {
                if (
                    childFolder.DefaultItemType == OlItemType.olMailItem
                    &&  (
                            childFolder.Folders.Count > 0
                            || childFolder.Items.Count > 0  
                        )
                    )
                {

                    StoreFolder childFolderModel = new StoreFolder()
                    {
                        Name = childFolder.Name,
                        FullPath = childFolder.FullFolderPath,
                        EntryId = childFolder.EntryID,
                        ParentFolder = rootFolderModel, 
                        FoldersCount = childFolder.Folders.Count, 
                        MailItemsCount = childFolder.Items.Count
                    };

                    rootFolderModel.Folders.Add(childFolderModel);

                    //foreach (object item in childFolder.Items)
                    //{
                    //    if (item is MailItem mailItem)
                    //    {
                    //        StoreEmailItem mailItemModel = new StoreEmailItem()
                    //        {
                    //            ParentFolder = childFolderModel,
                    //            EntryId = mailItem.EntryID,
                    //            Subject = mailItem.Subject,
                    //            Body = mailItem.Body,
                    //            SentOn = mailItem.SentOn
                    //        };

                    //        childFolderModel.EmailItems.Add(mailItemModel);
                    //    }
                    //}
                }
            }

            return rootFolderModel;
        }

        public StoreFolder? GetStoreFolder(string entryId)
        {
            if( entryId == null || string.IsNullOrEmpty(entryId) )
            {
                throw new ArgumentNullException(nameof(entryId));
            }

            Application application = new();
            NameSpace outlookNamespaces = application.GetNamespace("MAPI");

            // Login using default profile
            outlookNamespaces.Logon(application.DefaultProfileName);

            Store store = outlookNamespaces.Stores[storeName];
            MAPIFolder rootFolder = store.GetRootFolder();

            foreach (MAPIFolder childFolder in rootFolder.Folders)
            {
                if (childFolder.EntryID == entryId)
                {
                    return new StoreFolder()
                        {
                            Name = childFolder.Name,
                            FullPath = childFolder.FullFolderPath,
                            EntryId = childFolder.EntryID,
                            MailItemsCount = childFolder.Items.Count,
                            FoldersCount = childFolder.Folders.Count
                        };
                }
            }

            return null;
        }

        public void ExportFolder(string folderEntryId, string archiveRootFolder)
        {
            if (folderEntryId == null || string.IsNullOrEmpty(folderEntryId))
            {
                throw new ArgumentNullException(nameof(folderEntryId));
            }
            if (archiveRootFolder == null || string.IsNullOrEmpty(archiveRootFolder))
            {
                throw new ArgumentNullException(nameof(archiveRootFolder));
            }

            Application application = new();
            NameSpace outlookNamespaces = application.GetNamespace("MAPI");

            // Login using default profile
            outlookNamespaces.Logon(application.DefaultProfileName);

            Store store = outlookNamespaces.Stores[storeName];
            MAPIFolder rootFolder = store.GetRootFolder();

            MAPIFolder? mapiFolderToExport = null;
            foreach (MAPIFolder childFolder in rootFolder.Folders)
            {
                if (childFolder.EntryID == folderEntryId)
                {
                    mapiFolderToExport = childFolder; 

                    break;
                }
            }

            if(mapiFolderToExport == null)
            {
                return;
            }

            DirectoryInfo archiveDirectory = new DirectoryInfo(archiveRootFolder);

            foreach (object item in mapiFolderToExport.Items)
            {
                if (item is MailItem mailItem)
                {
                    try
                    {

                        #region Get Mail Item information

                        string senderEmailAddress = mailItem.SenderEmailAddress.Trim();
                        string senderName = mailItem.SenderName.Trim();
                        DateTime sent = mailItem.SentOn;
                        string to = string.IsNullOrEmpty(mailItem.To) ? string.Empty : mailItem.To.Trim();
                        string cc = string.IsNullOrEmpty(mailItem.CC) ? string.Empty : mailItem.CC.Trim();
                        string bcc = string.IsNullOrEmpty(mailItem.BCC) ? string.Empty : mailItem.BCC.Trim();
                        string subject = string.IsNullOrEmpty(mailItem.Subject) ? string.Empty : mailItem.Subject.Trim();
                        string body = string.IsNullOrEmpty(mailItem.Body) ? string.Empty : mailItem.Body.Trim();
                        int numberOfAttachments = mailItem.Attachments.Count;

                        #endregion

                        // create folders by sender
                        DirectoryInfo folderBySenderEmailAddress = archiveDirectory;
                        string folderName = string.Empty;
                        if (IsValidEmail(senderEmailAddress))
                        {
                            folderName =
                                mapiFolderToExport.Name == "Sent Items"
                                    ? $"{CleanDirectoryName(string.IsNullOrEmpty(to) ? cc : to)}"
                                    //: $"{CleanDirectoryName(senderName)} from {senderEmailAddress}";
                                    : $"{CleanDirectoryName(senderName)}";
                            if (folderName.Length > 75)
                            {
                                folderName = folderName[..75];
                            }

                            folderBySenderEmailAddress = archiveDirectory.CreateSubdirectory(CleanDirectoryName(folderName));
                        }

                        // create folders by sent date
                        DirectoryInfo folderBySentOn = archiveDirectory.CreateSubdirectory(sent.ToString("yyyy-MM-dd"));

                        // Format archive file content
                        string fileName = $"{folderName} on {sent:yyyy-MM-dd HH-mm-ss}";

                        string content = 
$@"From: {senderName}, {senderEmailAddress}
To: {to}; CC: {cc}; BCC: {bcc}
Sent on: {sent:yyyy-MM-dd HH:mm:ss}
Attachments: {numberOfAttachments}
Subject: {subject}
Message:
{body}";

                        // Save message info in files
                        using (StreamWriter outputFileByEmail = new(Path.Combine(folderBySenderEmailAddress.FullName, $"{fileName}.txt")))
                        {
                            outputFileByEmail.Write(content);
                        }
                        using (StreamWriter outputFileBySentOn = new(Path.Combine(folderBySentOn.FullName, $"{fileName}.txt")))
                        {
                            outputFileBySentOn.Write(content);
                        }

                        // Work with attachments
                        if(numberOfAttachments > 0)
                        {
                            // Create attachment folders
                            DirectoryInfo attachmentFolderBySenderEmailAddress = folderBySenderEmailAddress.CreateSubdirectory($"{fileName}.attachments");
                            DirectoryInfo attachmentFolderBySentOn = folderBySentOn.CreateSubdirectory($"{fileName}.attachments");

                            // Loop though attachments and save them as files
                            foreach(Microsoft.Office.Interop.Outlook.Attachment attachment in mailItem.Attachments)
                            {
                                try
                                {
                                    attachment.SaveAsFile(Path.Combine(attachmentFolderBySenderEmailAddress.FullName, attachment.FileName));
                                    attachment.SaveAsFile(Path.Combine(attachmentFolderBySentOn.FullName, attachment.FileName));
                                }
                                catch (System.Exception ex)
                                {
                                    Debug.WriteLine(ex);
                                }
                            }
                        }
                    }
                    catch (System.Exception ex) 
                    { 
                        Debug.WriteLine(ex);
                    }
                }

                GC.Collect();
            }
        }


        private static bool IsValidEmail(string email)
        {
            return MailAddress.TryCreate(email, out _);
        }
        private static string CleanDirectoryName(string inFolderName)
        {
            return inFolderName
                .Replace("\\", "")
                .Replace("/", "")
                .Replace(":", "")
                .Replace("*", "")
                .Replace("?", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("|", "")
                .Replace("\"", "")
                ;
        }
    }
}
