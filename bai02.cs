package bai02;

import java.util.ArrayList;
import java.util.Scanner;

/**
 * Lop cha mo ta thong tin chung cua mot cuon sach.
 */
class Sach
{
    protected String maSach;
    protected String ngayNhap;
    protected double donGia;
    protected int soLuong;
    protected String nhaXuatBan;

    public Sach(String maSach, String ngayNhap,
                double donGia, int soLuong,
                String nhaXuatBan)
    {
        this.maSach = maSach;
        this.ngayNhap = ngayNhap;
        this.donGia = donGia;
        this.soLuong = soLuong;
        this.nhaXuatBan = nhaXuatBan;
    }

    /**
     * Tinh thanh tien.
     */
    public double tinhThanhTien()
    {
        return soLuong * donGia;
    }

    public String getNhaXuatBan()
    {
        return nhaXuatBan;
    }

    public String getMaSach()
    {
        return maSach;
    }

    public double getDonGia()
    {
        return donGia;
    }

    public int getSoLuong()
    {
        return soLuong;
    }
}

/**
 * Lop mo ta sach giao khoa.
 */
class SachGiaoKhoa extends Sach
{
    private String tinhTrang;

public SachGiaoKhoa(String maSach, String ngayNhap,
                    double donGia, int soLuong,
                    String nhaXuatBan, String tinhTrang)
{
    super(maSach, ngayNhap, donGia, soLuong, nhaXuatBan);
    this.tinhTrang = tinhTrang;
}

/**
 * Tinh thanh tien cua sach giao khoa.
 * Sach moi tinh 100 phan tram don gia.
 * Sach cu tinh 50 phan tram don gia.
 */
@Override
    public double tinhThanhTien()
{
    if (tinhTrang.equalsIgnoreCase("moi"))
    {
        return soLuong * donGia;
    }
    else
    {
        return soLuong * donGia * 0.5;
    }
}

public String getTinhTrang()
{
    return tinhTrang;
}
}

/**
 * Lop mo ta sach tham khao.
 */
class SachThamKhao extends Sach
{
    private double thue;

public SachThamKhao(String maSach, String ngayNhap,
                    double donGia, int soLuong,
                    String nhaXuatBan, double thue)
{
    super(maSach, ngayNhap, donGia, soLuong, nhaXuatBan);
    this.thue = thue;
}

/**
 * Tinh thanh tien cua sach tham khao.
 */
@Override
    public double tinhThanhTien()
{
    return soLuong * donGia + thue;
}

public double getThue()
{
    return thue;
}
}

/**
 * Lop chay chuong trinh quan ly sach.
 */
public class Main
{
    public static void main(String[] args)
    {

        Scanner sc = new Scanner(System.in);

        // Tao danh sach sach
        ArrayList<Sach> danhSach = new ArrayList<>();

        // Tao 3 sach giao khoa
        danhSach.add(new SachGiaoKhoa(
                "GK01", "01/09/2026",
                50000, 10, "Kim Dong", "moi"
        ));

        danhSach.add(new SachGiaoKhoa(
                "GK02", "02/09/2026",
                60000, 8, "Kim Dong", "cu"
        ));

        danhSach.add(new SachGiaoKhoa(
                "GK03", "03/09/2026",
                70000, 12, "Giao Duc", "moi"
        ));

        // Tao 3 sach tham khao
        danhSach.add(new SachThamKhao(
                "TK01", "01/09/2026",
                80000, 5, "Tre", 10000
        ));

        danhSach.add(new SachThamKhao(
                "TK02", "02/09/2026",
                90000, 7, "Tre", 15000
        ));

        danhSach.add(new SachThamKhao(
                "TK03", "03/09/2026",
                100000, 4, "Giao Duc", 20000
        ));

        // Tinh tong thanh tien tung loai
        double tongSachGiaoKhoa = 0;
        double tongSachThamKhao = 0;

        for (Sach sach : danhSach)
        {

            if (sach instanceof SachGiaoKhoa) {
            tongSachGiaoKhoa += sach.tinhThanhTien();
        }

        if (sach instanceof SachThamKhao) {
            tongSachThamKhao += sach.tinhThanhTien();
        }
    }

    System.out.println("Tong thanh tien sach giao khoa: "
                + tongSachGiaoKhoa);

    System.out.println("Tong thanh tien sach tham khao: "
                + tongSachThamKhao);

    // Nhap nha xuat ban K
    System.out.print("Nhap ten nha xuat ban K: ");
    String k = sc.nextLine();

    System.out.println("\nCac sach giao khoa cua nha xuat ban "
                + k + ":");

    boolean timThay = false;

        for (Sach sach : danhSach) {

            if (sach instanceof SachGiaoKhoa
                    && sach.getNhaXuatBan().equalsIgnoreCase(k)) {

                System.out.println(
                        "Ma sach: " + sach.getMaSach()
                        + ", Nha xuat ban: " + sach.getNhaXuatBan()
                        + ", Thanh tien: " + sach.tinhThanhTien()
                );

    timThay = true;
            }
        }

        if (!timThay)
{
    System.out.println("Khong tim thay sach giao khoa.");
}

// Tim thanh tien cao nhat
double max = danhSach.get(0).tinhThanhTien();

for (Sach sach : danhSach)
{
    if (sach.tinhThanhTien() > max)
    {
        max = sach.tinhThanhTien();
    }
}

System.out.println("\nThanh tien cao nhat: " + max);

sc.close();
    }
}