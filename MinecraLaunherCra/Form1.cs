using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.Version;
using DiscordRPC;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Security.Policy;

namespace MinecraLaunherCra
{
    public partial class Form1 : Form
    {
        public DiscordRpcClient clientDiscord;
        Form2 form2 = new Form2();
        Proximamente prox = new Proximamente();
        Empezando em = new Empezando();
        private string archivoConfiguracion = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TheNewRoot", "config.json");
        private Configuracion configuracion;
        public Form1()
        {
            InitializeComponent();
        }


        private void path()
        {

            MinecraftPath path = new MinecraftPath();
            var launcher = new CMLauncher(path);
            foreach (var item in launcher.GetAllVersions())
            {
                if (item.MType != MVersionType.Snapshot && item.MType != MVersionType.OldBeta && item.MType != MVersionType.OldAlpha)
                {
                    comboBox1.Items.Add(item.Name);
                }
            }
        }


        public void discord()
        {
            clientDiscord = new DiscordRpcClient("");
            clientDiscord.SetPresence(new RichPresence()
            {
                Details = "En main menu",
                State = "Starting minecraft",
                Assets = new Assets()
                {
                    LargeImageKey = "logo",
                    LargeImageText = "Oficial TheNewR00t Launcher",

                },
                Buttons = new DiscordRPC.Button[]
                {
                    new DiscordRPC.Button() { Label = "Download", Url = "https://github.com/TheNewR00t/TheNewR00tLauncher/releases" },
                    new DiscordRPC.Button() { Label = "Trailer", Url = "https://youtube.com/" }
                }
            });
            
            clientDiscord.Initialize();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            discord();
            path();
            CargarConfiguracion();

            string pastebinUrl = "https://pastebin.com/raw/ZVyQKTuY"; // URL proporcionada
            string pastebinUrlVersion = "https://pastebin.com/raw/XtD5gnF4";

            // Instanciamos HttpClient
            using (WebClient client = new WebClient())
            {
                try
                {
                    string content = client.DownloadString(pastebinUrl);
                    richTextBox1.Text = content;
                }
                catch (Exception ex)
                {
                    richTextBox1.Text = "Error: " + ex.Message;
                }

            }

            using (WebClient webClient = new WebClient())
            {
                try
                {
                    string pastebinContent = webClient.DownloadString(pastebinUrlVersion);

                    if (int.TryParse(pastebinContent, out int pastebinNumber))
                    {
                        if (int.TryParse(label2.Text, out int labelNumber))
                        {
                            if (labelNumber < pastebinNumber)
                            {
                                DialogResult result = MessageBox.Show("There is a new update!!! do you want to update?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (result == DialogResult.Yes)
                                {
                                    string url = "https://github.com/TheNewR00t/TheNewR00tLauncher/releases";
                                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                                    this.Close();
                                }
                                else
                                {
                                    
                                }
                            }

                            if (labelNumber == pastebinNumber)
                            {
                                
                            }
                        }
                        else
                        {
                            MessageBox.Show("El número en el label no es válido.", "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El contenido de Pastebin no es un número válido.", "Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el contenido de Pastebin: " + ex.Message, "Error");
                }
            }

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Pon a username!!!", "Error");
            }
            else
            {
                MinecraftPath path = new MinecraftPath();
                var launcher = new CMLauncher(path);
                launcher.ProgressChanged += (s, e) =>
                {
                    progressBar1.Value = (e.ProgressPercentage);
                };

                var launchOption = new MLaunchOption
                {
                    MaximumRamMb = form2.RamScroll.Value,
                    ServerIp = $"{form2.IpServer.Text}",
                    Session = MSession.CreateOfflineSession(textBox1.Text),
                    GameLauncherName = "TheNewRootLauncher",
                    VersionType = "TheNewRoot v1.9"
                };


                var process = await launcher.CreateProcessAsync(comboBox1.Text, launchOption);
                process.Start();

                // Oculta el launcher
                this.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string url = "https://discord.gg/q2DewS9P9p";
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/TheNewR00t/TheNewR00tLauncher/releases";
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!form2.IsDisposed)
            {
                form2.Show();
            }
            else
            {
                form2.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            prox.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            prox.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CargarConfiguracion()
        {
            try
            {
                if (File.Exists(archivoConfiguracion))
                {
                    string json = File.ReadAllText(archivoConfiguracion);
                    configuracion = JsonConvert.DeserializeObject<Configuracion>(json);
                    if (configuracion != null)
                    {
                        textBox1.Text = configuracion.Name;
                        comboBox1.Text = configuracion.Version;
                        form2.RamScroll.Value = configuracion.Ram;
                    }
                }
                else
                {
                    configuracion = new Configuracion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la configuración: " + ex.Message);
            }
        }

        private void GuardarConfiguracion()
        {
            try
            {
                string carpetaTheNewRoot = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TheNewRoot");
                if (configuracion == null)
                {
                    configuracion = new Configuracion();
                }

                if (!Directory.Exists(carpetaTheNewRoot))
                {
                    Directory.CreateDirectory(carpetaTheNewRoot);
                }

                if (clientDiscord != null)
                {
                    clientDiscord.Dispose();
                }

                configuracion.Name = textBox1.Text;
                configuracion.Version = comboBox1.Text;
                configuracion.Ram = form2.RamScroll.Value;
                string json = JsonConvert.SerializeObject(configuracion);
                File.WriteAllText(archivoConfiguracion, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la configuración: " + ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            GuardarConfiguracion();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
} 
