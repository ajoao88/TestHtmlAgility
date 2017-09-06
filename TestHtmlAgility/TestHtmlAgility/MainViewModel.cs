using Android.Widget;
using HtmlAgilityPack;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestHtmlAgility {
    class MainViewModel : INotifyPropertyChanged {
        private string _testeNormal;
        private string _testeAspx;
        private string _testeHttps;
        private string _testePaginaDesejada;

        public MainViewModel() {
            TestarCommand = new Command(ExecTestes);
        }

        public Command TestarCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string TesteNormal {
            get { return _testeNormal; }
            set {
                _testeNormal = value;
                OnPropertyChanged();
            }
        }

        public string TesteAspx {
            get { return _testeAspx; }
            set {
                _testeAspx = value;
                OnPropertyChanged();
            }
        }

        public string TesteHttps {
            get { return _testeHttps; }
            set {
                _testeHttps = value;
                OnPropertyChanged();
            }
        }

        public string TestePaginaDesejada {
            get { return _testePaginaDesejada; }
            set {
                _testePaginaDesejada = value;
                OnPropertyChanged();
            }
        }

        
        public async Task<string> TesteConteudo(string url) {
            try {
                string resultado = "";
                

                HtmlWeb htmlWeb = new HtmlWeb();
                HtmlDocument doc = await htmlWeb.LoadFromWebAsync(url);

                resultado = doc.DocumentNode.Descendants("title").FirstOrDefault().InnerText;

                return resultado;
            } catch (Exception ex) {
                throw;
            }
            
        }
        
        public async void ExecTestes() {
            try {
                this.TesteNormal = "Erro";
                this.TesteAspx = "Erro";
                this.TesteHttps = "Erro";
                this.TestePaginaDesejada = "Erro";
                this.TesteNormal = await TesteConteudo("http://www25.senado.leg.br/web/transparencia/sen");
                this.TesteAspx = await TesteConteudo("http://www.nfe.fazenda.gov.br/portal/listaConteudo.aspx?tipoConteudo=tW+YMyk/50s=");
                this.TesteHttps = await TesteConteudo("https://www.fazenda.sp.gov.br/nfe/");
                this.TestePaginaDesejada = await TesteConteudo("https://www.nfe.fazenda.gov.br/portal/informe.aspx?ehCTG=false");
            } catch (HtmlWebException ex) {
                if (ex != null) {
                    Debug.WriteLine(ex.Message);
                    await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
                }
            } catch (Exception ex) {
                if (ex != null) {
                    Debug.WriteLine(ex.Message);
                    await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
                }
                
            }
        }
    }
}
