using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PapirKamenMakaze
{

    class DBkomunikacija
    {

        public static MySqlDataReader DBRow (string ime)
        {
            var name = ime;
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=newuser;password=newuser;database=pkm_skor;");
            string CitanjeIzBaze = "select * from pkm_skor.rezultat where Ime = '" + name + "';";
            MySqlCommand CitanjeIzDB = new MySqlCommand(CitanjeIzBaze, con);

            con.Open();
            MySqlDataReader reader = CitanjeIzDB.ExecuteReader();
            
            return reader;
        }

        public static void InsertDataIntoDB(string name, int i)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=newuser;password=newuser;database=pkm_skor;");
            if (NumberofVictories(name) == 0)
            {
                //create new record
                MySqlCommand CreateNewDBRecord = new MySqlCommand($"INSERT INTO pkm_skor.rezultat SET Ime='{name}',Rezultat={i}", con);
                con.Open();
                CreateNewDBRecord.ExecuteNonQuery();
                con.Close();    
            }

            else
            {
   
                //update the record with new value
                MySqlCommand UpdateDBRecord = new MySqlCommand($"UPDATE pkm_skor.rezultat SET Rezultat={i} WHERE Ime='{name}'", con);
                con.Open();
                UpdateDBRecord.ExecuteNonQuery();
                con.Close();
            }
            
        }

        public static string Welcome(string ime)
        {
            var Reader = DBRow(ime);

            if (Reader.Read())
            {
                return "Vas broj pobeda je: " + Reader.GetString("Rezultat");
            }
            else
            {
                return "Srecno sa prvom igrom!";
            }
        }


        public static int NumberofVictories (string ime)
        {
            var Reader = DBRow(ime);
            if (Reader.Read())
            {
                int x = Int32.Parse(Reader.GetString("Rezultat"));
                return x;
            }
            else
            {
                return 0;
            }
        }





    }
}
