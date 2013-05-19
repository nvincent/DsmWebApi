namespace DsmWebApi.Dsm.Share
{
    using System;

    /// <summary>
    /// Status of a DSM shared folder.
    /// </summary>
    [Flags]
    public enum DsmShareStatus
    {
        /// <summary>
        /// The encrypted share is not mounted.
        /// </summary>
        Unmounted = 1,

        /// <summary>
        /// The share is encrypted.
        /// </summary>
        Encrypted = 2,

        /// <summary>
        /// The encrypted share is mounted automatically on startup.
        /// </summary>
        MountAutomaticallyOnStartup = 4,

        /// <summary>
        /// Unknown flag.
        /// </summary>
        Unknown8 = 8,

        /// <summary>
        /// Unknown flag. Seems to be set on system default shares (music / photo / video).
        /// </summary>
        Unknown16 = 16,

        /// <summary>
        /// Unknown flag. Seems to be set on system default shares (music / photo / video).
        /// </summary>
        Unknown32 = 32,

        /// <summary>
        /// File indexing is enabled on the share.
        /// </summary>
        EnableFileIndexing = 64,

        /// <summary>
        /// Editing Windows ACL is allowed on the share.
        /// </summary>
        AllowEditingWindowsAccessControlList = 128,

        /// <summary>
        /// The recycle bin is enabled on the share.
        /// </summary>
        RecycleBinEnabled = 256,

        /// <summary>
        /// Access to the recycle bin is restricted to administrators on the share.
        /// </summary>
        RestrictAccessToRecycleBinToAdministratorsOnly = 512,

        /// <summary>
        /// Files and folders are hidden from users without permissions.
        /// </summary>
        HideFoldersAndFilesFromUsersWithoutPermissions = 1024
    }
}
