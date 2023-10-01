using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiInputDataMahasiswa
{
    public partial class Form1 : Form
    {
        private List<Mahasiswa> list = new List<Mahasiswa>();
        public Form1()
        {
            InitializeComponent();
            inisialisasiListView();
        }

        private void inisialisasiListView()
        {
            lvwMahasiswa.View = View.Details;
            lvwMahasiswa.FullRowSelect = true;
            lvwMahasiswa.GridLines = true;

            lvwMahasiswa.Columns.Add("No", 30, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nim", 91, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nama", 200, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Kelas", 70, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nilai", 50, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Nilai Huruf", 80, HorizontalAlignment.Center);
        }

        private void ResetForm()
        {
            txtNim.Clear();
            txtNama.Clear();
            txtKelas.Clear();
            txtNilai.Clear();
        }

        private bool NumericOnly(KeyPressEventArgs e)
        {
            var strValid = "0123456789";
            if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
            {
               
                if (strValid.IndexOf(e.KeyChar) < 0)
                {
                    return true;
                }
                return false;
            }
            else
                return false;
        }

        private void TampilkanData()
        {
            
            lvwMahasiswa.Items.Clear();
            
            foreach (var mhs in list)
            {
                var noUrut = lvwMahasiswa.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mhs.Nim);
                item.SubItems.Add(mhs.Nama);
                item.SubItems.Add(mhs.Kelas);
                item.SubItems.Add(mhs.Nilai.ToString());
                item.SubItems.Add(mhs.NilaiH);
                
                lvwMahasiswa.Items.Add(item);
            }
        }


        private void btnTampilkanData_Click(object sender, EventArgs e)
        {
            TampilkanData();
        }

        private void lvwMahasiswa_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void txtNilai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            
            Mahasiswa mhs = new Mahasiswa();
            
            mhs.Nim = txtNim.Text;
            mhs.Nama = txtNama.Text;
            mhs.Kelas = txtKelas.Text;
            mhs.Nilai = int.Parse(txtNilai.Text);
           
            
            if (mhs.Nilai > 80)
            {
                mhs.NilaiH = "A";
            }else if (mhs.Nilai > 60)
            {
                mhs.NilaiH = "B";
            }else if (mhs.Nilai > 40)
            {
                mhs.NilaiH = "C";
            }else if (mhs.Nilai > 20)
            {
                mhs.NilaiH = "D";
            }
            else
            {
                mhs.NilaiH = "E";
            }
            
            
            list.Add(mhs);
            var msg = "Data mahasiswa berhasil disimpan.";
            
            MessageBox.Show(msg, "Informasi", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
            
            ResetForm();
        }

        private void btnHapus_Click_1(object sender, EventArgs e)
        {
            if (lvwMahasiswa.SelectedItems.Count > 0)
            {

                var konfirmasi = MessageBox.Show("Apakah data mahasiswa ingin dihapus ? ", "Konfirmasi",

                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (konfirmasi == DialogResult.Yes)
                {

                    var index = lvwMahasiswa.SelectedIndices[0];

                    list.RemoveAt(index);

                    TampilkanData();
                }
            }
            else
            {
                MessageBox.Show("Data mahasiswa belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }

    internal class Mahasiswa
    {
        public string Nim;
        public string Nama;
        public string Kelas;
        public int Nilai;
        public string NilaiH;

        
    }
}
