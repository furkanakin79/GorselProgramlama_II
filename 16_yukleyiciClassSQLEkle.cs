using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;
using System.IO;            // FileStream, Stream ve FileMode sınıfları
using System.Reflection;    // Assembly sınıfı

namespace SQLEkle
{
    [RunInstaller(true)]
    public partial class yukleyiciClassSQLEkle : System.Configuration.Install.Installer
    {
        // SQL2019-SSEI-Expr.exe dosyasının yukleneceği özel klasör belirleniyor.
        public static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SQL2019-SSEI-Expr.exe";
        public yukleyiciClassSQLEkle()
        {
            InitializeComponent();
            FileStream filestream = new FileStream(path, FileMode.Create);
            Stream readstream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SQLEkle.SQLSetupFile.SQL2019-SSEI-Expr.exe");
            CopyStream(readstream, filestream);
        }

        void CopyStream(Stream readStream, Stream writeStream)
        {
            // readstrean nesnesi writestream nesnesine byte'lar halinde kopyalanacaktır. Bu amaçla buffer dizisi tanınlannıştır. 
            byte[] buffer = new byte[256];
            // readstream nesnesinden her seferde 256 byte okunarak buffer dizisine atilmaya çalışılmaktadır. 
            int bufferLength = readStream.Read(buffer, 0, 256);
            //bufferLength>0 yani steram'de hala okunacak byte varsa okumaya devam et 
            while (bufferLength > 0)
            {
                // okunan bölünü yazılacak stream'e yaz 
                writeStream.Write(buffer, 0, bufferLength);
                bufferLength = readStream.Read(buffer, 0, 256);
            }
            writeStream.Close();
            readStream.Close();
        }
    }
}
