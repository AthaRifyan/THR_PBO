class Program
{
    static void Main()
    {
        Console.Write("Jenis karyawan:\n1. Karyawan Tetap\n2. Karyawan Kontrak\n3. Karyawan Magang\nPilih 1/2/3: ");
        string pilihan = Console.ReadLine();
        Console.Write("Masukkan Nama: ");
        string nama = Console.ReadLine();
        Console.Write("Masukkan ID: ");
        string id = Console.ReadLine();
        Console.Write("Masukkan Gaji Pokok: ");
        double gajiPokok = Convert.ToDouble(Console.ReadLine());

        Karyawan karyawan;

        if (pilihan == "1")
        {
            karyawan = new Tetap(nama, id, gajiPokok);
        }
        else if (pilihan == "2")
        {
            karyawan = new Kontrak(nama, id, gajiPokok);
        }
        else if (pilihan == "3")
        {
            karyawan = new Magang(nama, id, gajiPokok);
        }
        else
        {
            Console.WriteLine("Pilihan tidak valid");
            return;
        }

        Console.WriteLine($"\nNama: {nama}\nID: {id}\nGaji akhir: Rp.{karyawan.HitungGaji()}");
    }
}

class Karyawan
{
    private string nama;
    private string id;
    public double gajiPokok { get; set; }

    public Karyawan(string nama, string id, double gajiPokok)
    {
        this.nama = nama;
        this.id = id;
        this.gajiPokok = gajiPokok;
    }

    public virtual double HitungGaji()
    {
        return gajiPokok;
    }
}

class Tetap : Karyawan
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

class Kontrak : Karyawan
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

class Magang : Karyawan
{
    public Magang(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok)
    {
    }

    public override double HitungGaji()
    {
        return gajiPokok;
    }
}