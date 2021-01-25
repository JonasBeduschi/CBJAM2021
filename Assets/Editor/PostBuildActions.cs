using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;

public static class PostBuildActions
{
    /* BACKUP
     * [PostProcessBuildAttribute(1)]
     * public static void OnPostProcessBuild(BuildTarget target, ring targetPath)
    */
    /// <summary>DO NOT CHANGE this method's signature</summary>
    [PostProcessBuildAttribute(1)]
    public static void OnPostProcessBuild(BuildTarget target, string targetPath)
    {
        string path = Path.Combine(targetPath, "Build/UnityLoader.js");
        string text = File.ReadAllText(path);
        text = text.Replace("UnityLoader.SystemInfo.mobile", "false");
        File.WriteAllText(path, text);

        CreateWebConfig(targetPath);
        CreateHTAccess(Path.Combine(targetPath, "Build/"));
    }

    public static void CreateWebConfig(string targetPath)
    {
        string path = Path.Combine(targetPath, "web.config");
        string text = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n" +
                        "<configuration>\r\n" +
                        "    <system.webServer>\r\n" +
                        "            <staticContent>\r\n" +
                        "                    <remove fileExtension=\".unityweb\" />\r\n" +
                        "                    <mimeMap fileExtension=\".unityweb\" mimeType=\"application/octet-stream\" />\r\n" +
                        "					<mimeMap fileExtension=\".mem\" mimeType=\"application/octet-stream\" />\r\n" +
                        "					<mimeMap fileExtension=\".data\" mimeType=\"application/octet-stream\" />\r\n" +
                        "					<mimeMap fileExtension=\".memgz\" mimeType=\"application/octet-stream\" />\r\n" +
                        "					<mimeMap fileExtension=\".datagz\" mimeType=\"application/octet-stream\" />\r\n" +
                        "					<mimeMap fileExtension=\".jsgz\" mimeType=\"application/x-javascript; charset=UTF-8\" />\r\n" +
                        "            </staticContent>\r\n" +
                        "            <rewrite>\r\n" +
                        "                    <outboundRules>\r\n" +
                        "                        <rule name=\"Append gzip Content-Encoding header\">\r\n" +
                        "                            <match serverVariable=\"RESPONSE_Content-Encoding\" pattern=\".*\" />\r\n" +
                        "                            <conditions>\r\n" +
                        "                                    <add input=\"{REQUEST_FILENAME}\" pattern=\"\\.unityweb$\" />\r\n" +
                        "                            </conditions>\r\n" +
                        "                            <action type=\"Rewrite\" value=\"gzip\" />\r\n" +
                        "                        </rule>\r\n" +
                        "						<rule name=\"Append br Content-Encoding header\">\r\n" +
                        "                            <match serverVariable=\"RESPONSE_Content-Encoding\" pattern=\".*\" />\r\n" +
                        "                            <conditions>\r\n" +
                        "                                    <add input=\"{REQUEST_FILENAME}\" pattern=\"\\.unityweb$\" />\r\n" +
                        "                            </conditions>\r\n" +
                        "                            <action type=\"Rewrite\" value=\"br\" />\r\n" +
                        "                        </rule>\r\n" +
                        "                    </outboundRules>\r\n" +
                        "            </rewrite>\r\n" +
                        "    </system.webServer>\r\n" +
                        "</configuration>\r\n";

        File.WriteAllText(path, text);
    }

    public static void CreateHTAccess(string targetPath)
    {
        string path = Path.Combine(targetPath, ".htaccess");
        string text = "<IfModule mod_mime.c>\r\n" +
                        "  AddEncoding br .unityweb\r\n" +
                        "</IfModule>\r\n";
        File.WriteAllText(path, text);
    }
}