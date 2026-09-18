using System.Collections.Generic;

package bai04;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Lop cha mo ta thong tin chung cua sach.
 */
class Sach
{
    protected String maSach;
    protected LocalDate ngayNhap;
    protected double donGia;
    protected int soLuong;
    protected String nhaXuatBan;

    public Sach()
    {
    }

    public Sach(String maSach, LocalDate ngayNhap,
                double donGia, int soLuong,
                String nhaXuatBan)
    {
        this.maSach = maSach;
        this.ngayNhap = ngayNhap;
        this.donGia = donGia;
        this.soLuong = soLuong;
        this.nhaXuatBan = nhaXuatBan;
    }

    public String getMaSach()
    {
        return maSach;
    }

    public void setMaSach(String maSach)
    {
        this.maSach = maSach;
    }

    public LocalDate getNgayNhap()
    {
        return ngayNhap;
    }

    public void setNgayNhap(LocalDate ngayNhap)
    {
        this.ngayNhap = ngayNhap;
    }

    public double getDonGia()
    {
        return donGia;
    }

    public void setDonGia(double donGia)
    {
        this.donGia = donGia;
    }

    public int getSoLuong()
    {
        return soLuong;
    }

    public void setSoLuong(int soLuong)
    {
        this.soLuong = soLuong;
    }

    public String getNhaXuatBan()
    {
        return nhaXuatBan;
    }

    public void setNhaXuatBan(String nhaXuatBan)
    {
        this.nhaXuatBan = nhaXuatBan;
    }

    public double getThanhTien()
    {
        return soLuong * donGia;
    }

    @Override
    public String toString()
    {
        return "Ma sach: " + maSach
                + ", Ngay nhap: " + ngayNhap
                + ", Don gia: " + donGia
                + ", So luong: " + soLuong
                + ", Nha xuat ban: " + nhaXuatBan
                + ", Thanh tien: " + getThanhTien();
    }
}

/**
 * Lop mo ta sach giao khoa.
 */
class SachGiaoKhoa extends Sach
{
    private boolean tinhTrang;

public SachGiaoKhoa()
{
}

public SachGiaoKhoa(String maSach, LocalDate ngayNhap,
                    double donGia, int soLuong,
                    String nhaXuatBan, boolean tinhTrang)
{
    super(maSach, ngayNhap, donGia, soLuong, nhaXuatBan);
    this.tinhTrang = tinhTrang;
}

public boolean getTinhTrang()
{
    return tinhTrang;
}

public void setTinhTrang(boolean tinhTrang)
{
    this.tinhTrang = tinhTrang;
}

@Override
    public double getThanhTien()
{
    if (tinhTrang)
    {
        return soLuong * donGia;
    }

    return soLuong * donGia * 0.5;
}

@Override
    public String toString()
{
    return super.toString()
            + ", Tinh trang: "
            + (tinhTrang ? "Moi" : "Cu");
}
}

/**
 * Lop mo ta sach tham khao.
 */
class SachThamKhao extends Sach
{
    private double thue;

public SachThamKhao()
{
}

public SachThamKhao(String maSach, LocalDate ngayNhap,
                    double donGia, int soLuong,
                    String nhaXuatBan, double thue)
{
    super(maSach, ngayNhap, donGia, soLuong, nhaXuatBan);
    this.thue = thue;
}

public double getThue()
{
    return thue;
}

public void setThue(double thue)
{
    this.thue = thue;
}

@Override
    public double getThanhTien()
{
    return soLuong * donGia + thue;
}

@Override
    public String toString()
{
    return super.toString()
            + ", Thue: " + thue;
}
}

/**
 * Lop quan ly danh sach sach.
 */
class DanhSachSach
{
    private List<Sach> list;
    private int count;

    public DanhSachSach(int size)
    {
        list = new ArrayList<>();
        count = 0;
    }

    /**
     * Them sach vao danh sach.
     */
    public boolean them(Sach sach)
    {
        if (count >= list.size() && list instanceof ArrayList) {
            list.add(sach);
            count++;
            return true;
        }

        list.add(sach);
        count++;
        return true;
    }

    /**
     * Tinh tong thanh tien sach giao khoa.
     */
    public double tinhTongThanhTienSGK()
    {
        double tong = 0;

        for (Sach sach : list)
        {
            if (sach instanceof SachGiaoKhoa) {
            tong += sach.getThanhTien();
        }
    }

        return tong;
    }

/**
 * Tinh tong thanh tien sach tham khao.
 */
public double tinhTongThanhTienSTK()
{
    double tong = 0;

    for (Sach sach : list) {
            if (sach instanceof SachThamKhao) {
                tong += sach.getThanhTien();
            }
        }

        return tong;
    }

    /**
     * Tim sach giao khoa theo nha xuat ban.
     */
    public List<Sach> timSachGiaoKhoaTheoNXB(String nhaXuatBan)
{
    List<Sach> ketQua = new ArrayList<>();

    for (Sach sach : list) {
            if (sach instanceof SachGiaoKhoa
                    && sach.getNhaXuatBan().equalsIgnoreCase(nhaXuatBan)) {
                ketQua.add(sach);
            }
        }

        return ketQua;
    }

    /**
     * Tim thanh tien cao nhat.
     */
    public double timThanhTienCaoNhat()
{

    if (list.isEmpty())
    {
        return 0;
    }

    double max = list.get(0).getThanhTien();

    for (Sach sach : list) {
            if (sach.getThanhTien() > max) {
                max = sach.getThanhTien();
            }
        }

        return max;
    }

    @Override
    public String toString()
{
    String result = "";

    for (Sach sach : list) {
            result += sach + "\n";
        }

        return result;
    }
}

/**
 * Lop chay chuong trinh.
 */
public class Main
{

    public static void main(String[] args)
    {

        Scanner sc = new Scanner(System.in);

        DanhSachSach danhSach = new DanhSachSach(10);

        // Tao san 3 sach giao khoa
        danhSach.them(new SachGiaoKhoa(
                "GK01",
                LocalDate.of(2026, 9, 1),
                50000,
                10,
                "Kim Dong",
                true
        ));

        danhSach.them(new SachGiaoKhoa(
                "GK02",
                LocalDate.of(2026, 9, 2),
                60000,
                8,
                "Kim Dong",
                false
        ));

        danhSach.them(new SachGiaoKhoa(
                "GK03",
                LocalDate.of(2026, 9, 3),
                70000,
                12,
                "Giao Duc",
                true
        ));

        // Tao san 3 sach tham khao
        danhSach.them(new SachThamKhao(
                "TK01",
                LocalDate.of(2026, 9, 1),
                80000,
                5,
                "Tre",
                10000
        ));

        danhSach.them(new SachThamKhao(
                "TK02",
                LocalDate.of(2026, 9, 2),
                90000,
                7,
                "Tre",
                15000
        ));

        danhSach.them(new SachThamKhao(
                "TK03",
                LocalDate.of(2026, 9, 3),
                100000,
                4,
                "Giao Duc",
                20000
        ));

        int choice;

        do
        {
            System.out.println("\n========== MENU ==========");
            System.out.println("1. Xuat danh sach sach");
            System.out.println("2. Tinh tong thanh tien sach giao khoa");
            System.out.println("3. Tinh tong thanh tien sach tham khao");
            System.out.println("4. Tim sach giao khoa theo nha xuat ban");
            System.out.println("5. Tim thanh tien cao nhat");
            System.out.println("0. Thoat");
            System.out.print("Nhap lua chon: ");

            choice = sc.nextInt();
            sc.nextLine();

            switch (choice)
            {

                case 1:
                    System.out.println("\nDanh sach sach:");
                    System.out.println(danhSach);
                    break;

                case 2:
                    System.out.println(
                            "\nTong thanh tien sach giao khoa: "
                            + danhSach.tinhTongThanhTienSGK()
                    );
                    break;

                case 3:
                    System.out.println(
                            "\nTong thanh tien sach tham khao: "
                            + danhSach.tinhTongThanhTienSTK()
                    );
                    break;

                case 4:
                    System.out.print(
                            "\nNhap ten nha xuat ban: "
                    );

                    String nxb = sc.nextLine();

                    List<Sach> ketQua =
                            danhSach.timSachGiaoKhoaTheoNXB(nxb);

                    if (ketQua.isEmpty())
                    {
                        System.out.println(
                                "Khong tim thay sach giao khoa."
                        );
                    }
                    else
                    {
                        System.out.println(
                                "\nSach giao khoa cua nha xuat ban "
                                + nxb + ":"
                        );

                        for (Sach sach : ketQua)
                        {
                            System.out.println(sach);
                        }
                    }

                    break;

                case 5:
                    System.out.println(
                            "\nThanh tien cao nhat: "
                            + danhSach.timThanhTienCaoNhat()
                    );
                    break;

                case 0:
                    System.out.println("Ket thuc chuong trinh.");
                    break;

                default:
                    System.out.println(
                            "Lua chon khong hop le."
                    );
            }

        } while (choice != 0);

        sc.close();
    }
}