using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace explorest
{
    public class MainWindowForms : Form, IMainView
    {
        private MainPresenter _pres;
        private GroupBox _reqGrpBox;
        private GroupBox _resGrpBox;
        private ComboBox _reqMethodCb;
        private TextBox _reqEndpointTb;
        private Button _exploreBtn;
        private SplitContainer _resSc;
        private DataGridView _resHeadersDgv;
        private TextBox _resTextTb;

        public MainWindowForms(MainPresenter pres)
        {
            InitializeComponent();
            _pres = pres;
            _pres.View = this;
            _pres.Initialize();
        }

        private void InitializeComponent()
        {
            Text = "explorest";
            Size = new Size(1000, 700);
            MinimumSize = new Size(1000, 700);
            MaximumSize = new Size(1000, 700);

            _reqGrpBox = new GroupBox();
            _reqGrpBox.Text = "Request";
            _reqGrpBox.AutoSize = false;
            _reqGrpBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _reqGrpBox.Location = new Point(0, 0);
            _reqGrpBox.MinimumSize = new Size(500, 50);
            _reqGrpBox.MaximumSize = new Size(2000, 50);
            _reqGrpBox.Size = new Size(992, 50);
            Controls.Add(_reqGrpBox);

            _reqMethodCb = new ComboBox();
            _reqMethodCb.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            _reqMethodCb.DropDownStyle = ComboBoxStyle.DropDownList;
            _reqMethodCb.Location = new Point(7, 18);
            _reqMethodCb.MinimumSize = new Size(100, 20);
            _reqMethodCb.MaximumSize = new Size(100, 20);
            _reqMethodCb.Size = new Size(100, 20);
            _reqGrpBox.Controls.Add(_reqMethodCb);

            _reqEndpointTb = new TextBox();
            _reqEndpointTb.Location = new Point(117, 16);
            _reqEndpointTb.MinimumSize = new Size(100, 18);
            _reqEndpointTb.MaximumSize = new Size(2000, 18);
            _reqEndpointTb.Size = new Size(790, 18);
            _reqGrpBox.Controls.Add(_reqEndpointTb);

            _exploreBtn = new Button();
            _exploreBtn.Text = "explore";
            _exploreBtn.Click += (object sender, EventArgs e) => { _pres.SendRequest(); };
            _exploreBtn.Location = new Point(920, 16);
            _exploreBtn.MinimumSize = new Size(60, 22);
            _exploreBtn.MaximumSize = new Size(60, 22);
            _exploreBtn.Size = new Size(60, 22);
            _reqGrpBox.Controls.Add(_exploreBtn);

            _resGrpBox = new GroupBox();
            _resGrpBox.Text = "Response";
            _resGrpBox.AutoSize = false;
            _resGrpBox.Location = new Point(0, 54);
            _resGrpBox.MinimumSize = new Size(500, 50);
            _resGrpBox.MaximumSize = new Size(2000, 50);
            _resGrpBox.Size = new Size(992, 620);
            Controls.Add(_resGrpBox);

            _resSc = new SplitContainer();
            _resSc.Dock = DockStyle.Fill;
            _resSc.AutoSize = true;
            _resSc.Orientation = Orientation.Horizontal;
            _resGrpBox.Controls.Add(_resSc);

            _resHeadersDgv = new DataGridView();
            _resHeadersDgv.Dock = DockStyle.Fill;
            _resSc.Panel1.Controls.Add(_resHeadersDgv);

            _resTextTb = new TextBox();
            _resTextTb.Multiline = true;
            _resTextTb.Dock = DockStyle.Fill;
            _resTextTb.Enabled = true;
            _resTextTb.ReadOnly = true;
            _resTextTb.ScrollBars = ScrollBars.Both;
            _resSc.Panel2.Controls.Add(_resTextTb);
        }

        #region IMainView
        public string RequestEndpoint
        { 
            get
            {
                return _reqEndpointTb.Text;
            }
        }

        public IList<string> RequestMethods
        {
            set
            {
                _reqMethodCb.DataSource = value;
            }
        }

        public string RequestMethod
        {
            get
            {
                return (string)_reqMethodCb.SelectedItem;
            }
            set
            {
                _reqMethodCb.SelectedItem = value;
            }
        }

        public IDictionary<string, string> ResponseHeaders
        {
            set
            {
                _resHeadersDgv.DataSource = value.ToList();
                _resHeadersDgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                _resHeadersDgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                _resHeadersDgv.AutoSize = true;
            }
        }

        public string ResponseStatusText
        {
            set
            {
                _resGrpBox.Text = string.Format("Response: {0}", value);
            }
        }

        public string ResponseText
        {
            set
            {
                _resTextTb.Text = value;
            }
        }

        public string Message
        {
            set
            {
                MessageBox.Show(value);
            }
        }
        #endregion
    }
}

