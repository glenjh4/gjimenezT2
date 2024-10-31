namespace gjimenezT2.Views;

public partial class Login : ContentPage
{
    // Listas de usuarios y contraseñas
    string[] users = { "Carlos", "Ana", "José" };
    string[] passwords = { "carlos123", "ana123", "jose123" };

    public Login()
	{
		InitializeComponent();
	}

    // Se ejecutará al hacer clic en el botón "Ingresar"
    private async void OnIngresarClicked(object sender, EventArgs e)
    {
        string usuario = txtUsuario.Text;
        string contrasena = txtContrasena.Text;
        
        // Busca en el listado de Usuarios
        int userIndex = Array.IndexOf(users, usuario);

        // Verifica si el usuario y la contraseña existen
        if (userIndex != -1 && passwords[userIndex] == contrasena) 
        {
            //Acceso correcto - Mensaje de Ingreso
            await DisplayAlert("Acceso Exitoso", $"¡Bienvenido {users[userIndex]}!", "ACEPTAR");

            // Redirige al usuario a la página vHome
            Application.Current.MainPage = new vHome();
        }
        else 
        {
            //Acceso Incorrecto - Mensaje de error
            IngresarMessage.Text = "Usuario o contraseña incorrectos";
        }
    }
}