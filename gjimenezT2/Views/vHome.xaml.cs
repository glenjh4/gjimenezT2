namespace gjimenezT2.Views;

public partial class vHome : ContentPage
{
		public vHome()
		{
			InitializeComponent();
		}
    private void btnCalNot_Clicked(object sender, EventArgs e)
    {
        bool continuar = true;
        if (string.IsNullOrWhiteSpace(dpFecha.Date.ToString()))
        {
            DisplayAlert("Alerta", "Favor seleccionar la Fecha", "Cerrar");
            continuar = false;
        }
        else if (pkEstudiantes.SelectedIndex == -1)
        {
            DisplayAlert("Alerta", "Favor seleccionar un Estudiante", "Cerrar");
            continuar = false;
        }
        else if (string.IsNullOrWhiteSpace(txtNSeguimiento1.Text))
        {
            // Label Alerta Rojo
            lblAlerta.Text = "El campo Seguimiento 1 no puede estar vacío";
            lblAlerta.IsVisible = true;
            continuar = false;
        }
        else if (string.IsNullOrWhiteSpace(txtNExamen1.Text))
        {
            // Label Alerta Rojo
            lblAlerta.Text = "El campo Examen 1 no puede estar vacío";
            lblAlerta.IsVisible = true;
            continuar = false;
        }
        else if (string.IsNullOrWhiteSpace(txtNSeguimiento2.Text))
        {
            // Label Alerta Rojo
            lblAlerta.Text = "El campo Seguimiento 2 no puede estar vacío";
            lblAlerta.IsVisible = true;
            continuar = false;
        }
        else if (string.IsNullOrWhiteSpace(txtNExamen2.Text))
        {
            // Label Alerta Rojo
            lblAlerta.Text = "El campo Examen 2 no puede estar vacío";
            lblAlerta.IsVisible = true;
            continuar = false;
        }

        if (continuar)
        {
            double seguimiento1 = Convert.ToDouble(txtNSeguimiento1.Text);
            double examen1 = Convert.ToDouble(txtNExamen1.Text);
            double seguimiento2 = Convert.ToDouble(txtNSeguimiento2.Text);
            double examen2 = Convert.ToDouble(txtNExamen2.Text);

            if (seguimiento1 < 0 || seguimiento1 > 10)
            {
                // Label Alerta Rojo
                lblAlerta.Text = "La nota del Seguimiento 1 debe ser Mayor o igual que 0 y Menor o igual a 10";
                lblAlerta.IsVisible = true;
            }
            else if (examen1 < 0 || examen1 > 10)
            {
                // Label Alerta Rojo
                lblAlerta.Text = "La nota del Examen 1 debe ser Mayor o igual que 0 y Menor o igual a 10";
                lblAlerta.IsVisible = true;
            }
            else if (seguimiento2 < 0 || seguimiento2 > 10)
            {
                // Label Alerta Rojo
                lblAlerta.Text = "La nota del Seguimiento 2 debe ser Mayor o igual que 0 y Menor o igual a 10";
                lblAlerta.IsVisible = true;
            }
            else if (examen2 < 0 || examen2 > 10)
            {
                // Label Alerta Rojo
                lblAlerta.Text = "La nota del Examen 2 debe ser Mayor o igual que 0 y Menor o igual a 10";
                lblAlerta.IsVisible = true;
            }
            else
            {
                lblAlerta.IsVisible = false;

                string estudiante = pkEstudiantes.Items[pkEstudiantes.SelectedIndex].ToString();
                string fecha = dpFecha.Date.ToString();

                double notaSeguimiento1 = seguimiento1 * 0.3;
                double notaExamen1 = examen1 * 0.2;
                double notaPacial1 = notaSeguimiento1 + notaExamen1;

                double notaSeguimiento2 = seguimiento2 * 0.3;
                double notaExamen2 = examen2 * 0.2;
                double notaPacial2 = notaSeguimiento2 + notaExamen2;

                double notaFinal = notaPacial1 + notaPacial2;

                string estado = "";
                if (notaFinal > 7)
                {
                    estado = "APROBADO";
                    lblNotaFinal.TextColor = Colors.Green;
                }
                else if (notaFinal >= 5 && notaFinal < 7)
                {
                    estado = "COMPLEMENTARIO";
                    lblNotaFinal.TextColor = Colors.Yellow;
                }
                else
                {
                    estado = "REPROBADO";
                    lblNotaFinal.TextColor = Colors.Red;
                }

                lblParcial1.Text = Math.Round(notaPacial1, 2).ToString();
                lblParcial2.Text = Math.Round(notaPacial2, 2).ToString();
                lblNotaFinal.Text = Math.Round(notaFinal, 2).ToString();
                DisplayAlert("Mensaje de Calificaciones", "Fecha: " + fecha + "\nEstudiante: " + estudiante + "\nParcial 1: " + Math.Round(notaPacial1, 2) + "\nParcial 2: " + Math.Round(notaPacial2, 2) + "\nNota Final: " + Math.Round(notaFinal, 2) + "\nEstado: " + estado, "OK");
            }
        }
    }

    private void btnBorInf_Clicked(object sender, EventArgs e)
    {
        pkEstudiantes.SelectedIndex = -1;
        txtNSeguimiento1.Text = "";
        txtNExamen1.Text = "";
        lblParcial1.Text = "";
        txtNSeguimiento2.Text = "";
        txtNExamen2.Text = "";
        lblParcial2.Text = "";
        lblNotaFinal.Text = "";
    }

}