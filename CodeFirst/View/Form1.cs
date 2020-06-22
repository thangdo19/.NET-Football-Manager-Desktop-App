using CodeFirst.BLL;
using CodeFirst.DAL;
using CodeFirst.DTO;
using CodeFirst.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirst
{
    public partial class Form1 : Form
    {
        public delegate void GiveData(Player player);
        public GiveData gd { get; set; }
        public Form1()
        {
            InitializeComponent();
            InitializeClub();
        }
        private void InitializeClub()
        {
            List<Club> data = ClubHandler.Instance.GetListClub();
            cob_Search.Items.AddRange(data.ToArray());
            cob_Search.SelectedIndex = 0;
        }

        private void bt_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = PlayerHandler.Instance.GetListPlayers();
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var listId = new List<string>();
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    var player = (Player)row.DataBoundItem;
                    listId.Add(player.Id_player);
                }
                if (PlayerHandler.Instance.DeletePlayers(listId))
                {
                    MessageBox.Show("Delete thanh cong");
                    bt_Show_Click(null, null);
                }
            }
        }

        private void EditPlayer(Player player)
        {
            if (PlayerHandler.Instance.EditPlayer(player))
            {
                MessageBox.Show("Thanh cong");
                bt_Show_Click(null, null);
            }
            else
                MessageBox.Show("Khong thanh cong");
        }

        private void AddPlayer(Player player)
        {
            if (PlayerHandler.Instance.AddPlayer(player))
            {
                MessageBox.Show("Thanh cong");
                bt_Show_Click(null, null);
            }
            else
                MessageBox.Show("Khong thanh cong");
        }

        private void bt_Search_Click(object sender, EventArgs e)
        {
            var player_name = tb_Search.Text;
            var club = (Club)cob_Search.SelectedItem;
            dataGridView1.DataSource = PlayerHandler.Instance.SearchPlayers(player_name, club);
            tb_Search.Text = "";
        }

        private void bt_Sort_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = PlayerHandler.Instance
                .SortListPlayers(
                    (
                        List<Player>)dataGridView1.DataSource, 
                        PlayerHandler.Instance.SortByName
                    );
        }

        private void bt_Edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Ban phai chon mot player de chinh sua");
                return;
            }
            var thePlayer = (Player)dataGridView1.SelectedRows[0].DataBoundItem;
            Form2 f2 = new Form2(this);
            f2.DisableIDPlayer();
            gd(thePlayer);
            f2.Show();
            f2.the_del = new Form2.AddUpdateDelegate(EditPlayer);
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            f2.the_del = new Form2.AddUpdateDelegate(AddPlayer);
        }
    }
}
