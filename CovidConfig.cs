using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace tpmodul8_103022300131
{
    public class CovidConfig
    {
        public string satuan_suhu { get; set; } = "celcius";
        public int batas_hari_deman { get; set; } = 14;
        public string pesan_ditolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        public string pesan_diterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        private const string filePath = "covid_config.json";

        public CovidConfig()
        {
            LoadConfig();
        }

        public void LoadConfig()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var config = JsonSerializer.Deserialize<CovidConfig>(json);
                this.satuan_suhu = config.satuan_suhu;
                this.batas_hari_deman = config.batas_hari_deman;
                this.pesan_ditolak = config.pesan_ditolak;
                this.pesan_diterima = config.pesan_diterima;
            }
        }

        public void UbahSatuan()
        {
            if (satuan_suhu == "celcius")
                satuan_suhu = "fahrenheit";
            else
                satuan_suhu = "celcius";
        }
    }
}

