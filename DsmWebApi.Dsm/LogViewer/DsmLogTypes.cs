namespace DsmWebApi.Dsm.LogViewer
{
    /// <summary>
    /// Names of log types supported on a DSM.
    /// </summary>
    public class DsmLogTypes
    {
        /// <summary>
        /// Name of the log that contains system related entries.
        /// </summary>
        public const string System = "system";

        /// <summary>
        /// Name of the log that contains connection related entries.
        /// </summary>
        public const string Connection = "connection";

        /// <summary>
        /// Name of the log that contains copy related entries.
        /// </summary>
        public const string Copy = "copy";

        /// <summary>
        /// Name of the log that contains backup related entries.
        /// </summary>
        public const string Backup = "backup";

        /// <summary>
        /// Name of the log that contains network backup related entries.
        /// </summary>
        public const string NetworkBackup = "network_backup";

        /// <summary>
        /// Name of the log that contains FTP related entries.
        /// </summary>
        public const string Ftp = "xfer_ftp";

        /// <summary>
        /// Name of the log that contains FM related entries.
        /// </summary>
        public const string FM = "xfer_fm";

        /// <summary>
        /// Name of the log that contains samba related entries.
        /// </summary>
        public const string Samba = "xfer_samba";

        /// <summary>
        /// Name of the log that contains WebDAV related entries.
        /// </summary>
        public const string WebDav = "xfer_webdav";
    }
}
