using System;
using System.Windows.Forms; 
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text.Json;
using App_window_database;
using System.Text;

namespace ExchangeRateApp
{
    public partial class Form1 : Form
    {
        //
        //  Klient HTTP do obs³ugi po³¹czenia z zewnêtrznym API
        //
        private readonly HttpClient client;
        //
        //  Kontekst bazy danych kantoru
        //
        private dbContext kantor;
        public Form1()
        {
            client = new HttpClient();
            kantor = new dbContext();
            InitializeComponent();
        }
        //
        //  Elementy interfejsu
        //
        public Button download_button;
        public RichTextBox loaded_data_textbox;
        protected Label label1;
        public Button sort_up;
        public Button sort_down;
        public Button add_currency;
        public Button delete_currency;
        public Button clear_base;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox3;
        protected Label label2;
        protected Label label3;
        public Button search_currency;
        private RichTextBox richTextBox4;

        //
        //  Inicjalizacja okna aplikacji, wraz z wszystkimi przyciskami i funkcjami
        //
        private void InitializeComponent()
        {
            download_button = new Button();
            loaded_data_textbox = new RichTextBox();
            label1 = new Label();
            sort_up = new Button();
            sort_down = new Button();
            add_currency = new Button();
            delete_currency = new Button();
            clear_base = new Button();
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            richTextBox3 = new RichTextBox();
            label2 = new Label();
            label3 = new Label();
            search_currency = new Button();
            richTextBox4 = new RichTextBox();
            SuspendLayout();
            // 
            // download_button
            // 
            download_button.Location = new Point(502, 575);
            download_button.Name = "download_button";
            download_button.Size = new Size(177, 50);
            download_button.TabIndex = 0;
            download_button.Text = "Pobierz waluty z serwera";
            download_button.UseVisualStyleBackColor = true;
            download_button.Click += download_button_Click;
            // 
            // loaded_data_textbox
            // 
            loaded_data_textbox.Location = new Point(384, 51);
            loaded_data_textbox.Name = "loaded_data_textbox";
            loaded_data_textbox.Size = new Size(295, 518);
            loaded_data_textbox.TabIndex = 1;
            loaded_data_textbox.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(502, 18);
            label1.Name = "label1";
            label1.Size = new Size(177, 30);
            label1.TabIndex = 2;
            label1.Text = "Twoja baza walut";
            // 
            // sort_up
            // 
            sort_up.Location = new Point(26, 47);
            sort_up.Name = "sort_up";
            sort_up.Size = new Size(177, 50);
            sort_up.TabIndex = 3;
            sort_up.Text = "Sortuj rosn¹co";
            sort_up.UseVisualStyleBackColor = true;
            sort_up.Click += sort_up_Click;
            // 
            // sort_down
            // 
            sort_down.Location = new Point(26, 103);
            sort_down.Name = "sort_down";
            sort_down.Size = new Size(177, 50);
            sort_down.TabIndex = 4;
            sort_down.Text = "Sortuj malej¹co";
            sort_down.UseVisualStyleBackColor = true;
            sort_down.Click += sort_down_Click;
            // 
            // add_currency
            // 
            add_currency.Location = new Point(26, 159);
            add_currency.Name = "add_currency";
            add_currency.Size = new Size(177, 50);
            add_currency.TabIndex = 5;
            add_currency.Text = "Dodaj walutê";
            add_currency.UseVisualStyleBackColor = true;
            add_currency.Click += add_currency_Click;
            // 
            // delete_currency
            // 
            delete_currency.Location = new Point(26, 215);
            delete_currency.Name = "delete_currency";
            delete_currency.Size = new Size(177, 50);
            delete_currency.TabIndex = 6;
            delete_currency.Text = "Usuñ walutê";
            delete_currency.UseVisualStyleBackColor = true;
            delete_currency.Click += delete_currency_Click;
            // 
            // clear_base
            // 
            clear_base.Location = new Point(319, 575);
            clear_base.Name = "clear_base";
            clear_base.Size = new Size(177, 50);
            clear_base.TabIndex = 7;
            clear_base.Text = "Wyczyœæ bazê";
            clear_base.UseVisualStyleBackColor = true;
            clear_base.Click += clear_base_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(209, 159);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(70, 50);
            richTextBox1.TabIndex = 8;
            richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(209, 215);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(148, 50);
            richTextBox2.TabIndex = 9;
            richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(287, 159);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(70, 50);
            richTextBox3.TabIndex = 10;
            richTextBox3.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(209, 123);
            label2.Name = "label2";
            label2.Size = new Size(79, 30);
            label2.TabIndex = 11;
            label2.Text = "Waluta";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F);
            label3.Location = new Point(287, 123);
            label3.Name = "label3";
            label3.Size = new Size(55, 30);
            label3.TabIndex = 12;
            label3.Text = "Kurs";
            // 
            // search_currency
            // 
            search_currency.Location = new Point(26, 271);
            search_currency.Name = "search_currency";
            search_currency.Size = new Size(177, 50);
            search_currency.TabIndex = 13;
            search_currency.Text = "Wyszukaj walutê";
            search_currency.UseVisualStyleBackColor = true;
            search_currency.Click += search_currency_Click;
            // 
            // richTextBox4
            // 
            richTextBox4.Location = new Point(209, 271);
            richTextBox4.Name = "richTextBox4";
            richTextBox4.Size = new Size(148, 50);
            richTextBox4.TabIndex = 14;
            richTextBox4.Text = "";
            // 
            // Form1
            // 
            ClientSize = new Size(722, 646);
            Controls.Add(richTextBox4);
            Controls.Add(search_currency);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(richTextBox3);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            Controls.Add(clear_base);
            Controls.Add(delete_currency);
            Controls.Add(add_currency);
            Controls.Add(sort_down);
            Controls.Add(sort_up);
            Controls.Add(label1);
            Controls.Add(loaded_data_textbox);
            Controls.Add(download_button);
            Name = "Kantor";
            ResumeLayout(false);
            PerformLayout();
            RefreshCurrencyDatabaseDisplay();
        }

        //
        //  Funkcja obs³uguj¹ca przycisk pobierania kursów z zewnêtrznego API
        //
        private async void download_button_Click(object sender, EventArgs e)
        {
            string appId = "0f6fa859368245b9a7da40eab440282b";
            string call = $"https://openexchangerates.org/api/latest.json?app_id={appId}";

            try
            {
                kantor.Rates.RemoveRange(kantor.Rates);
                //  Wys³anie zapytania do API o JSONa z kursami walut
                string response = await client.GetStringAsync(call);

                //  Deserializacja otrzymanego JSONa
                Rates RateData = Rates.Deserialize(response);

                loaded_data_textbox.Text = RateData.ToString();

                //  Zapisanie kursów w bazie danych
                foreach (var rate in RateData.rates)
                {
                    dbStructure dbRate = new dbStructure
                    {
                        currency = rate.Key,
                        rate = (float)rate.Value
                    };

                    kantor.Rates.Add(dbRate);
                }   
                kantor.SaveChanges();
            }
            catch (Exception ex)
            {
                loaded_data_textbox.Text = "Wyst¹pi³ b³¹d: " + ex.Message;
            }
        }

        //
        //  Funkcja obs³uguj¹ca sortowanie rosn¹co
        //
        private void sort_up_Click (object sender, EventArgs e)
        {
            loaded_data_textbox.Clear();
            //  Pobieranie z bazy danych kursów posortowanych wzglêdem pola "rate"
            var sortedRates = kantor.Rates.OrderBy(r => r.rate).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var rate in sortedRates)
            {
                sb.AppendLine($"{rate.currency}: {rate.rate}");
            }

            loaded_data_textbox.Text = sb.ToString();
        }

        //
        //  Funkcja obs³uguj¹ca sortowanie rosn¹co
        //
        private void sort_down_Click(object sender, EventArgs e)
        {
            loaded_data_textbox.Clear();
            //  Pobieranie z bazy danych kursów posortowanych wzglêdem pola "rate"
            var sortedRates = kantor.Rates.OrderByDescending(r => r.rate).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var rate in sortedRates)
            {
                sb.AppendLine($"{rate.currency}: {rate.rate}");
            }

            loaded_data_textbox.Text = sb.ToString();
        }

        //
        //  Funkcja odpowiedzialna za dodawanie nowej, w³asnej waluty
        //
        private void add_currency_Click(object sender, EventArgs e)
        {
            string currency = richTextBox1.Text.Trim();
            float rate;

            //  Sprawdzenie, czy u¿ytkownik poda³ kurs w³asnej waluty w odpowiednim formacie
            if (float.TryParse(richTextBox3.Text.Trim(), out rate))
            {
                //  Dodanie nowego wpisu po udanej konwersji tekstu na float
                dbStructure dbRate = new dbStructure
                {
                    currency = currency,
                    rate = rate
                };

                kantor.Rates.Add(dbRate);
                kantor.SaveChanges();
                RefreshCurrencyDatabaseDisplay();

                // Wyœwietl komunikat o powodzeniu
                MessageBox.Show("Pomyœlnie dodano walutê.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Komunikat o b³êdzie, w przypadku niepoprawnego formatu
                MessageBox.Show("Wprowadzono nieprawid³ow¹ wartoœæ waluty.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //
        //  Funkcja odpowiedzialna za usuwanie waluty z bazy
        //
        private void delete_currency_Click(object sender, EventArgs e)
        {
            string currency = richTextBox2.Text.Trim();

            //  Wyszukanie w bazie pierwszego wyst¹pienia waluty pasuj¹cej do kryterium
            var rate = kantor.Rates.FirstOrDefault(r => r.currency == currency);

            if (rate != null)
            {
                // Jeœli waluta istnieje, usuñ j¹ z bazy danych
                kantor.Rates.Remove(rate);
                kantor.SaveChanges();
                RefreshCurrencyDatabaseDisplay();

                MessageBox.Show("Pomyœlnie usuniêto walutê.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Jeœli waluta nie istnieje, wyœwietl komunikat o b³êdzie
                MessageBox.Show("Nie znaleziono waluty o podanej nazwie.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //
        //  Wyszukanie wpisanej waluty
        //
        private void search_currency_Click(object sender, EventArgs e)
        {
            string currencyToSearch = richTextBox4.Text.Trim();

            //  Wyszukanie w bazie pierwszego wyst¹pienia waluty pasuj¹cej do kryterium
            var rate = kantor.Rates.FirstOrDefault(r => r.currency == currencyToSearch);

            if (rate != null)
            {
                // Jeœli waluta zosta³a znaleziona, wyœwietl jej kurs
                MessageBox.Show($"Kurs dla waluty {currencyToSearch}: {rate.rate}", "Wynik wyszukiwania", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Jeœli waluta nie zosta³a znaleziona, wyœwietl komunikat o braku wyników
                MessageBox.Show("Nie znaleziono wpisu dla podanej waluty.", "Brak wyników", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //
        //  Czyszczenie bazy danych
        //
        private void clear_base_Click(object sender, EventArgs e)
        {
            kantor.Rates.RemoveRange(kantor.Rates);
            kantor.SaveChanges();
            RefreshCurrencyDatabaseDisplay();
        }

        //
        //  Odœwie¿ listê walut i kursów
        //
        public void RefreshCurrencyDatabaseDisplay()
        {
            var rates = kantor.Rates.ToList();

            loaded_data_textbox.Clear();
            foreach (var rate in rates)
            {
                loaded_data_textbox.AppendText($"{rate.currency}: {rate.rate}\n");
            }
        }
    }
}
