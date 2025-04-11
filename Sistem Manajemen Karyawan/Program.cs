class Program
{
    static void Main()
    {
        Console.WriteLine("===== PROGRAM SISTEM MANAJEMEN KARYAWAN =====");
        Console.WriteLine("\nJenis Karyawan:\n1. Karyawan Tetap\n2. Karyawan Kontrak\n3. Karyawan Magang");
        Console.Write("\nPilih Jenis Karyawan (1/2/3): ");
        string jenisPilihan = Console.ReadLine();

        Console.Write("\nMasukkan Nama: ");
        string nama = Console.ReadLine();

        Console.Write("Masukkan ID: ");
        string id = Console.ReadLine();

        Console.Write("Masukkan Gaji Pokok: ");
        double gajiPokok = Convert.ToDouble(Console.ReadLine());

        jenisKaryawan karyawan;

        if (jenisPilihan == "1")
        {
            karyawan = new Tetap(nama, id, gajiPokok);
        }
        else if (jenisPilihan == "2")
        {
            karyawan = new Kontrak(nama, id, gajiPokok);
        }
        else if (jenisPilihan == "3")
        {
            karyawan = new Magang(nama, id, gajiPokok);
        }
        else
        {
            Console.WriteLine("Pilihan tidak valid");
            return;
        }

        Console.WriteLine("\n===== RINCIAN GAJI =====");
        Console.WriteLine($"\nNama: {nama}\nID: {id}\nGaji Akhir: Rp.{karyawan.HitungGaji()}");
    }
}

class jenisKaryawan
{
    private string nama;
    private string id;
    public double gajiPokok { get; set; }

    public jenisKaryawan(string nama, string id, double gajiPokok)
    {
        this.nama = nama;
        this.id = id;
        this.gajiPokok = gajiPokok;
    }

    public string Nama
    {
        get { return nama; }
        set { this.nama = value; }
    }

    public string ID
    {
        get { return id; }
        set { this.id = value; }
    }

    public double GajiPokok
    {
        get { return gajiPokok; }
        set { this.gajiPokok = value; }
    }
    public virtual double HitungGaji()
    {
        return gajiPokok;
    }
}

class Tetap : jenisKaryawan
{
    private double bonusTetap = 500000;

    public Tetap(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok)
    {
    }

    public override double HitungGaji()
    {
        return gajiPokok + bonusTetap;
    }
}

class Kontrak : jenisKaryawan
{
    private double potonganKontrak = 200000;

    public Kontrak(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok)
    {
    }

    public override double HitungGaji()
    {
        return gajiPokok - potonganKontrak;
    }
}

class Magang : jenisKaryawan
{
    public Magang(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok)
    {
    }

    public override double HitungGaji()
    {
        return gajiPokok;
    }
}
