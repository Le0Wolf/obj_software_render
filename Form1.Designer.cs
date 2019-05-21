namespace SoftwareRenderer
{
    using System.ComponentModel;
    using System.Windows.Forms;

    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openModelDlg = new System.Windows.Forms.OpenFileDialog();
            this.saveBmpDlg = new System.Windows.Forms.SaveFileDialog();
            this.backgroundColorDialog = new System.Windows.Forms.ColorDialog();
            this.meshColorDialog = new System.Windows.Forms.ColorDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.OpenButton = new System.Windows.Forms.ToolStripButton();
            this.SaveButton = new System.Windows.Forms.ToolStripButton();
            this.refreshButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.backgroundColorButton = new System.Windows.Forms.ToolStripButton();
            this.meshColorButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.projectionCombo = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.centerToXButton = new System.Windows.Forms.ToolStripButton();
            this.centerToYButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.RotateButton = new System.Windows.Forms.ToolStripButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.canvas = new System.Windows.Forms.PictureBox();
            this.scaleInput = new System.Windows.Forms.NumericUpDown();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleInput)).BeginInit();
            this.SuspendLayout();
            // 
            // openModelDlg
            // 
            this.openModelDlg.Filter = "3D Model files (*.obj)|*.obj";
            this.openModelDlg.Title = "Open 3D Model file (*.obj)";
            // 
            // saveBmpDlg
            // 
            this.saveBmpDlg.DefaultExt = "bmp";
            this.saveBmpDlg.Filter = "bmp | *.bmp";
            this.saveBmpDlg.Title = "Save Bmp as";
            // 
            // meshColorDialog
            // 
            this.meshColorDialog.Color = System.Drawing.Color.White;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenButton,
            this.SaveButton,
            this.refreshButton,
            this.toolStripSeparator1,
            this.backgroundColorButton,
            this.meshColorButton,
            this.toolStripSeparator2,
            this.projectionCombo,
            this.toolStripSeparator3,
            this.centerToXButton,
            this.centerToYButton,
            this.toolStripSeparator4,
            this.RotateButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // OpenButton
            // 
            this.OpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenButton.Image")));
            this.OpenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(23, 22);
            this.OpenButton.Text = "&Open";
            this.OpenButton.ToolTipText = "Open OBJ 3D";
            this.OpenButton.Click += new System.EventHandler(this.OpenClick);
            // 
            // SaveButton
            // 
            this.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
            this.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(23, 22);
            this.SaveButton.Text = "&Save";
            this.SaveButton.ToolTipText = "Save as Bitmap image";
            this.SaveButton.Click += new System.EventHandler(this.SaveClick);
            // 
            // refreshButton
            // 
            this.refreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshButton.Image")));
            this.refreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(23, 22);
            this.refreshButton.Text = "Refresh";
            this.refreshButton.Click += new System.EventHandler(this.RefreshClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // backgroundColorButton
            // 
            this.backgroundColorButton.BackColor = System.Drawing.Color.Black;
            this.backgroundColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.backgroundColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backgroundColorButton.Name = "backgroundColorButton";
            this.backgroundColorButton.Size = new System.Drawing.Size(23, 22);
            this.backgroundColorButton.Text = "Background color";
            this.backgroundColorButton.Click += new System.EventHandler(this.BackgroundColorClick);
            // 
            // meshColorButton
            // 
            this.meshColorButton.BackColor = System.Drawing.Color.White;
            this.meshColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.meshColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.meshColorButton.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.meshColorButton.Name = "meshColorButton";
            this.meshColorButton.Size = new System.Drawing.Size(23, 22);
            this.meshColorButton.Text = "Mesh color";
            this.meshColorButton.Click += new System.EventHandler(this.MeshColorClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // projectionCombo
            // 
            this.projectionCombo.Items.AddRange(new object[] {
            "X",
            "Y",
            "Z"});
            this.projectionCombo.Name = "projectionCombo";
            this.projectionCombo.Size = new System.Drawing.Size(121, 25);
            this.projectionCombo.Text = "Projection";
            this.projectionCombo.ToolTipText = "Projection";
            this.projectionCombo.SelectedIndexChanged += new System.EventHandler(this.ProjectionCombo_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // centerToXButton
            // 
            this.centerToXButton.CheckOnClick = true;
            this.centerToXButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.centerToXButton.Image = ((System.Drawing.Image)(resources.GetObject("centerToXButton.Image")));
            this.centerToXButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.centerToXButton.Name = "centerToXButton";
            this.centerToXButton.Size = new System.Drawing.Size(70, 22);
            this.centerToXButton.Text = "Center to X";
            this.centerToXButton.CheckedChanged += new System.EventHandler(this.CenterToXButton_CheckedChanged);
            // 
            // centerToYButton
            // 
            this.centerToYButton.CheckOnClick = true;
            this.centerToYButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.centerToYButton.Image = ((System.Drawing.Image)(resources.GetObject("centerToYButton.Image")));
            this.centerToYButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.centerToYButton.Name = "centerToYButton";
            this.centerToYButton.Size = new System.Drawing.Size(70, 22);
            this.centerToYButton.Text = "Center to Y";
            this.centerToYButton.ToolTipText = "Center to Y";
            this.centerToYButton.CheckedChanged += new System.EventHandler(this.CenterToYButton_CheckedChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // RotateButton
            // 
            this.RotateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RotateButton.Image = ((System.Drawing.Image)(resources.GetObject("RotateButton.Image")));
            this.RotateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RotateButton.Name = "RotateButton";
            this.RotateButton.Size = new System.Drawing.Size(23, 22);
            this.RotateButton.Text = "Rotate";
            this.RotateButton.Visible = false;
            this.RotateButton.Click += new System.EventHandler(this.RotateButton_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // canvas
            // 
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 25);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(800, 425);
            this.canvas.TabIndex = 4;
            this.canvas.TabStop = false;
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseClick);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            // 
            // scaleInput
            // 
            this.scaleInput.DecimalPlaces = 1;
            this.scaleInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.scaleInput.Location = new System.Drawing.Point(12, 39);
            this.scaleInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.scaleInput.Name = "scaleInput";
            this.scaleInput.Size = new System.Drawing.Size(59, 20);
            this.scaleInput.TabIndex = 5;
            this.scaleInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scaleInput.ValueChanged += new System.EventHandler(this.ScaleInput_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scaleInput);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Software renderer test";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private OpenFileDialog openModelDlg;
        private SaveFileDialog saveBmpDlg;
        private ColorDialog backgroundColorDialog;
        private ColorDialog meshColorDialog;
        private ToolStrip toolStrip1;
        private ToolStripButton OpenButton;
        private ToolStripButton SaveButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton refreshButton;
        private ImageList imageList1;
        private PictureBox canvas;
        private ToolStripButton backgroundColorButton;
        private ToolStripButton meshColorButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripComboBox projectionCombo;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton centerToXButton;
        private ToolStripButton centerToYButton;
        private NumericUpDown scaleInput;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton RotateButton;
    }
}

