using System;
using System.Drawing;
using System.Windows.Forms;

namespace ControlinventarioAltoLantaño
{
    public partial class FormPrincipal : Form
    {
        private string rolUsuario;

        private MenuStrip menuPrincipal;
        private ToolStripMenuItem menuProductos;
        private ToolStripMenuItem menuMovimientos;
        private ToolStripMenuItem menuReportes;
        private ToolStripMenuItem menuUsuarios;
        private ToolStripMenuItem menuCerrarSesion;

        private Label lblBienvenida;
        private Panel panelStockTrozos;
        private Panel panelMovimientosHoy;
        private Panel panelStockCritico;
        private DataGridView dgvMovimientos;

        public FormPrincipal(string rol)
        {
            InitializeComponent();
            rolUsuario = rol;

            ConfigurarVentana();
            ConfigurarMenu();
            ConfigurarBienvenida();
            ConfigurarTarjetas();
            ConfigurarTabla();
            AplicarPermisosPorRol();
        }

        private void ConfigurarVentana()
        {
            this.Text = "Inventario Alto Lantaño - Panel Principal";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
        }

        private void ConfigurarMenu()
        {
            menuPrincipal = new MenuStrip();

            menuProductos = new ToolStripMenuItem("Productos");
            menuProductos.Click += MenuProductos_Click;

            menuMovimientos = new ToolStripMenuItem("Movimientos");
            menuMovimientos.Click += MenuMovimientos_Click;

            menuReportes = new ToolStripMenuItem("Reportes");
            menuReportes.Click += MenuReportes_Click;

            menuUsuarios = new ToolStripMenuItem("Usuarios");
            menuUsuarios.Click += MenuUsuarios_Click;

            menuCerrarSesion = new ToolStripMenuItem("Cerrar sesión");
            menuCerrarSesion.Alignment = ToolStripItemAlignment.Right;
            menuCerrarSesion.Click += MenuCerrarSesion_Click;

            menuPrincipal.Items.Add(menuProductos);
            menuPrincipal.Items.Add(menuMovimientos);
            menuPrincipal.Items.Add(menuReportes);
            menuPrincipal.Items.Add(menuUsuarios);
            menuPrincipal.Items.Add(menuCerrarSesion);

            this.MainMenuStrip = menuPrincipal;
            this.Controls.Add(menuPrincipal);
        }

        private void ConfigurarBienvenida()
        {
            lblBienvenida = new Label();
            lblBienvenida.Text = "Bienvenido, rol: " + rolUsuario;
            lblBienvenida.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblBienvenida.AutoSize = true;
            lblBienvenida.Location = new Point(20, 40);
            this.Controls.Add(lblBienvenida);
        }

        private void ConfigurarTarjetas()
        {
            panelStockTrozos = CrearTarjeta("Stock trozos (m³)", "1,248", Color.White, 20);
            panelMovimientosHoy = CrearTarjeta("Movimientos hoy", "7", Color.White, 300);
            panelStockCritico = CrearTarjeta("Stock crítico", "3", Color.LightYellow, 580);

            this.Controls.Add(panelStockTrozos);
            this.Controls.Add(panelMovimientosHoy);
            this.Controls.Add(panelStockCritico);
        }

        private Panel CrearTarjeta(string titulo, string valor, Color colorFondo, int posX)
        {
            Panel panel = new Panel();
            panel.Size = new Size(260, 90);
            panel.Location = new Point(posX, 90);
            panel.BackColor = colorFondo;
            panel.BorderStyle = BorderStyle.FixedSingle;

            Label lblTitulo = new Label();
            lblTitulo.Text = titulo;
            lblTitulo.Font = new Font("Segoe UI", 9);
            lblTitulo.ForeColor = Color.Gray;
            lblTitulo.Location = new Point(12, 12);
            lblTitulo.AutoSize = true;

            Label lblValor = new Label();
            lblValor.Text = valor;
            lblValor.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblValor.Location = new Point(12, 32);
            lblValor.AutoSize = true;

            panel.Controls.Add(lblTitulo);
            panel.Controls.Add(lblValor);

            return panel;
        }

        private void ConfigurarTabla()
        {
            dgvMovimientos = new DataGridView();
            dgvMovimientos.Location = new Point(20, 200);
            dgvMovimientos.Size = new Size(820, 300);
            dgvMovimientos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvMovimientos.Columns.Add("Fecha", "Fecha");
            dgvMovimientos.Columns.Add("Producto", "Producto");
            dgvMovimientos.Columns.Add("Tipo", "Tipo");
            dgvMovimientos.Columns.Add("Cantidad", "Cantidad");

            dgvMovimientos.Rows.Add("15-09-2026", "Trozo 40", "Recepción", "32 m³");
            dgvMovimientos.Rows.Add("15-09-2026", "Tabla exportación", "Despacho", "18 m³");

            this.Controls.Add(dgvMovimientos);
        }

        private void AplicarPermisosPorRol()
        {
            if (rolUsuario == "Supervisor")
            {
                menuUsuarios.Visible = false;
            }
        }

        private void MenuProductos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aquí abrirás el formulario de Productos.");
        }

        private void MenuMovimientos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aquí abrirás el formulario de Movimientos.");
        }

        private void MenuReportes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aquí abrirás el formulario de Reportes.");
        }

        private void MenuUsuarios_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aquí abrirás el formulario de Usuarios.");
        }

        private void MenuCerrarSesion_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Close();
        }
    }
}