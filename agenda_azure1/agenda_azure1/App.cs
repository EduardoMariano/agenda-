using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;


namespace agenda_azure1
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MobileServiceClient client;
            IMobileServiceTable<agenda> tabla;
            //client = new MobileServiceClient(Conexion.conexion);
            client = new MobileServiceClient(conn.ApplicationURL);
            tabla = client.GetTable<agenda>();

            Label titulo = new Label();
            titulo.Text = "Agenda";
            titulo.FontSize = 40;
            titulo.HorizontalTextAlignment = TextAlignment.Center;
                       
            Entry nombre = new Entry();
            nombre.Placeholder = "Nombre";
            Entry apellido = new Entry();
            apellido.Placeholder = "Apellido";
            Entry telefono = new Entry();
            telefono.Placeholder = "telefono";
            telefono.Keyboard = Keyboard.Numeric;
            

            Button guardar = new Button();
            guardar.Text = "Guardar Contacto";

            Button consultar = new Button();
            consultar.Text = "Consultar Contactos";

            Button eliminar = new Button();
            eliminar.Text = "Eliminar Contacto";


            ListView lista_nombre = new ListView();
            ListView lista_apellido = new ListView();

            guardar.Clicked += async (sender, args) =>
            {
                var datos = new agenda { Name = nombre.Text, LastNAme = apellido.Text, Cellphone = telefono.Text };
                await tabla.InsertAsync(datos);
                IEnumerable<agenda> items = await tabla.ToEnumerableAsync();
                string[] arreglo = new string[items.Count()];
                string[] arreglo2 = new string[items.Count()];
                int i = 0;
                foreach (var x in items)
                {
                    arreglo[i] = x.Name;
                    arreglo2[i] = x.LastNAme;
                    i++;
                }
                lista_nombre.ItemsSource = arreglo;
                lista_apellido.ItemsSource = arreglo2;
            };
            consultar.Clicked += async (sender, args) =>
            {
                IEnumerable<agenda> items = await tabla.ToEnumerableAsync();
                string[] arreglo = new string[items.Count()];
                string[] arreglo2 = new string[items.Count()];
                int i = 0;
                foreach (var x in items)
                {
                    arreglo[i] = x.Name;
                    arreglo2[i] = x.LastNAme;
                    i++;
                }
                lista_nombre.ItemsSource = arreglo;
                lista_apellido.ItemsSource = arreglo2;
            };
            

            eliminar.Clicked += async (sender, args) =>
            {
                IEnumerable<agenda> items = await tabla.ToEnumerableAsync();
                string[] arreglo = new string[items.Count()];
                string[] arreglo2 = new string[items.Count()];
                string[] ids = new string[items.Count()];
                string[] arreglo3 = new string[items.Count()];
                int i = 0;
                foreach (var x in items)
                {
                    arreglo[i] = x.Name;
                    arreglo2[i] = x.LastNAme;
                    ids[i] = x.Id;
                    arreglo3[i] = x.Cellphone;
                    if (x.Cellphone == telefono.Text)
                    {
                        if (x.Name != nombre.Text)
                        {
                            x.Name = nombre.Text;
                        }
                        if (x.LastNAme != apellido.Text)
                        {
                            x.LastNAme = apellido.Text;
                        }
                        await MainPage.DisplayAlert("Alerta", "Se elimino el contacto: ", "OK");
                        await tabla.DeleteAsync(x);
                    }
                    i++;
                }
                lista_nombre.ItemsSource = arreglo;
                lista_apellido.ItemsSource = arreglo2;
            };

            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Children = {
                        titulo,nombre,apellido,telefono,guardar,consultar,eliminar,lista_nombre,lista_apellido
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
