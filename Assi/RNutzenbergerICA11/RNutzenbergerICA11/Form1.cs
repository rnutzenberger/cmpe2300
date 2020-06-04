using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RNutzenbergerICA11
{
    public partial class Form1 : Form
    {
        //binding source is needed to assign the stuff to the data grid view
        BindingSource _BSource = new BindingSource();
        Dictionary<byte, int> _keyValues = new Dictionary<byte, int>();
        int _avgFreq;
        
        public Form1()
        {
            InitializeComponent();
            _DGV.DataSource = _BSource;
            _DGV.ColumnHeaderMouseClick += _DGV_ColumnHeaderMouseClick;
            _DGV.CellFormatting += _DGV_CellFormatting;
            _btnLoad.Click += _btnLoad_Click;
            _btnAvg.Click += _btnAvg_Click;
        }

        private void _btnAvg_Click(object sender, EventArgs e)
        {
            //remove every key value pair that is less than the average of every value in the dictionary
            foreach(KeyValuePair<byte,int> kvp in _keyValues.Where((kvp) => kvp.Value < _avgFreq).ToList())
            {
                _keyValues.Remove(kvp.Key);
            }
            ShowDictionary();
        }

        private void _btnLoad_Click(object sender, EventArgs e)
        {
            _DGV.Rows.Clear();
            _DGV.Refresh();
            _keyValues.Clear();

            OpenFileDialog _OFD = new OpenFileDialog();
            _OFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if(_OFD.ShowDialog()== DialogResult.OK)
            {
                //save each byte read into an array and then iterate through and 
                //add them to the dictionary
                byte[] bArr = File.ReadAllBytes(_OFD.FileName);
                foreach(byte b in bArr)
                {
                    //if (_keyValues == null)
                    //{
                    //    _keyValues.Add(b,1);
                    //}
                    if(!_keyValues.ContainsKey(b))
                    {
                        // if the key doesn't exist, add it to the dictionary
                        _keyValues.Add(b, 1);
                    }
                    else
                    {
                        //else just increment the value where the key is the same
                        _keyValues[b]++;
                    }

                }
                
            }
            ShowDictionary();
        }

        private void _DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //setting back colors based on their value compared to frequency
            if(e.ColumnIndex == 1)
            {
                if((int)e.Value < _avgFreq)
                {
                    e.CellStyle.BackColor = Color.Coral;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Green;
                }
            }
        }

        private void _DGV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //sorting stuff
            if(e.ColumnIndex == 0)
            {
                _keyValues = _keyValues.OrderBy((kvp) => kvp.Key).ToDictionary((key) => key.Key, (value) => value.Value);
            }
            //sorting by value first, key second
            if(e.ColumnIndex == 1)
            {
                List<KeyValuePair<byte,int>> temp = _keyValues.ToList();
                temp.Sort((a, b) =>
                {
                    if (a.Value == b.Value)
                    {
                        return a.Key.CompareTo(b.Key);
                    }
                    else return a.Value.CompareTo(b.Value);
                });

                _keyValues = temp.ToDictionary((key) => key.Key, (value) => value.Value);
            }
            ShowDictionary();
        }

        private void ShowDictionary()
        {
            _avgFreq = (int)_keyValues.Average((x) => x.Value);
            _btnAvg.Text = $"Average : {_avgFreq}";

            _BSource.DataSource = _keyValues;
            _DGV.Columns[0].HeaderText = "Key";
            _DGV.Columns[1].HeaderText = "Value";
            _DGV.Columns[0].DefaultCellStyle.Format = "X2";


        }
    }
}
