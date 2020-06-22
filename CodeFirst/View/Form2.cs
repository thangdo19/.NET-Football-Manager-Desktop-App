using CodeFirst.BLL;
using CodeFirst.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirst.View
{
    public partial class Form2 : Form
    {
        public delegate void AddUpdateDelegate(Player player);
        public AddUpdateDelegate the_del { get; set; }
        private Form1 f1;


        public Form2()
        {
            InitializeComponent();
            InitializeClub();
        }

        public Form2(Form1 f1) : this()
        {
            this.f1 = f1;
            this.f1.gd = new Form1.GiveData(TakeData);
        }
        private void InitializeClub()
        {
            List<Club> data = ClubHandler.Instance.GetListClub();
            cob_Club.Items.AddRange(data.ToArray());
            cob_Club.SelectedIndex = 0;
        }

        public void TakeData(Player player)
        {
            tb_IdPlayer.Text = player.Id_player;
            tb_Name.Text = player.Player_name;
            cob_Club.SelectedIndex = cob_Club.Items.IndexOf(new Club { Id_club = player.Id_club });
        }

        private void bt_OK_Click(object sender, EventArgs e)
        {
            var Id_player = tb_IdPlayer.Text;
            var Player_name = tb_Name.Text;
            Club club = (Club)cob_Club.SelectedItem;
            Player player = new Player
            {
                Id_player = Id_player,
                Player_name = Player_name,
                Id_club = club.Id_club
            };
            this.Hide();
            the_del(player);
        }

        public void DisableIDPlayer()
        {
            tb_IdPlayer.Enabled = false;
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

