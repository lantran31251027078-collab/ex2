package bai03;

import java.time.LocalDate;
import java.util.ArrayList;

/**
 * Lop cha mo ta thong tin chung cua giao dich.
 */
class GiaoDich
{
    protected String maGiaoDich;
    protected LocalDate ngayGiaoDich;
    protected double donGia;
    protected int soLuong;

    public GiaoDich(String maGiaoDich, LocalDate ngayGiaoDich,
                    double donGia, int soLuong)
    {
        this.maGiaoDich = maGiaoDich;
        this.ngayGiaoDich = ngayGiaoDich;
        this.donGia = donGia;
        this.soLuong = soLuong;
    }

    public double getThanhTien()
    {
        return soLuong * donGia;
    }

    public double getDonGia()
    {
        return donGia;
    }

    @Override
    public String toString()
    {
        return "Ma giao dich: " + maGiaoDich
                + ", Ngay giao dich: " + ngayGiaoDich
                + ", Don gia: " + donGia
                + ", So luong: " + soLuong;
    }
}

/**
 * Lop mo ta giao dich vang.
 */
class GiaoDichVang extends GiaoDich
{
    private String loaiVang;

public GiaoDichVang(String maGiaoDich, LocalDate ngayGiaoDich,
                    double donGia, int soLuong, String loaiVang)
{
    super(maGiaoDich, ngayGiaoDich, donGia, soLuong);
    this.loaiVang = loaiVang;
}

@Override
    public double getThanhTien()
{
    return soLuong * donGia;
}

@Override
    public String toString()
{
    return super.toString()
            + ", Loai vang: " + loaiVang
            + ", Thanh tien: " + getThanhTien();
}
}

/**
 * Lop mo ta giao dich tien te.
 */
class GiaoDichTienTe extends GiaoDich
{
    private double tiGia;
private String loaiTienTe;

public GiaoDichTienTe(String maGiaoDich, LocalDate ngayGiaoDich,
                      double donGia, int soLuong,
                      double tiGia, String loaiTienTe)
{
    super(maGiaoDich, ngayGiaoDich, donGia, soLuong);
    this.tiGia = tiGia;
    this.loaiTienTe = loaiTienTe;
}

@Override
    public double getThanhTien()
{
    if (loaiTienTe.equalsIgnoreCase("USD")
            || loaiTienTe.equalsIgnoreCase("EURO"))
    {
        return soLuong * donGia * tiGia;
    }

    return soLuong * donGia;
}

@Override
    public String toString()
{
    return super.toString()
            + ", Ti gia: " + tiGia
            + ", Loai tien te: " + loaiTienTe
            + ", Thanh tien: " + getThanhTien();
}
}

/**
 * Lop chay chuong trinh quan ly giao dich.
 */
public class Main
{
    public static void main(String[] args)
    {

        ArrayList<GiaoDich> danhSach = new ArrayList<>();

        // Tao 3 giao dich vang
        danhSach.add(new GiaoDichVang(
                "V01",
                LocalDate.of(2026, 9, 1),
                85000000,
                10,
                "9999"
        ));

        danhSach.add(new GiaoDichVang(
                "V02",
                LocalDate.of(2026, 9, 2),
                90000000,
                15,
                "SJC"
        ));

        danhSach.add(new GiaoDichVang(
                "V03",
                LocalDate.of(2026, 9, 3),
                95000000,
                8,
                "24K"
        ));

        // Tao 3 giao dich tien te
        danhSach.add(new GiaoDichTienTe(
                "TT01",
                LocalDate.of(2026, 9, 4),
                24000,
                1000,
                1,
                "VN"
        ));

        danhSach.add(new GiaoDichTienTe(
                "TT02",
                LocalDate.of(2026, 9, 5),
                24000,
                2000,
                1,
                "USD"
        ));

        danhSach.add(new GiaoDichTienTe(
                "TT03",
                LocalDate.of(2026, 9, 6),
                28000,
                1500,
                1,
                "EURO"
        ));

        // Tinh tong so luong tung loai
        int tongSoLuongVang = 0;
        int tongSoLuongTienTe = 0;

        // Tinh trung binh thanh tien giao dich tien te
        double tongThanhTienTienTe = 0;
        int soGiaoDichTienTe = 0;

        for (GiaoDich giaoDich : danhSach)
        {

            if (giaoDich instanceof GiaoDichVang) {
            tongSoLuongVang += giaoDich.soLuong;
        }

        if (giaoDich instanceof GiaoDichTienTe) {
            tongSoLuongTienTe += giaoDich.soLuong;
            tongThanhTienTienTe += giaoDich.getThanhTien();
            soGiaoDichTienTe++;
        }
    }

    double trungBinhThanhTienTienTe =
            tongThanhTienTienTe / soGiaoDichTienTe;

    // Xuat ket qua
    System.out.println("Tong so luong giao dich vang: "
                + tongSoLuongVang);

    System.out.println("Tong so luong giao dich tien te: "
                + tongSoLuongTienTe);

    System.out.println("Trung binh thanh tien giao dich tien te: "
                + trungBinhThanhTienTienTe);

    // Xuat giao dich co don gia > 1 ty
    System.out.println("\nCac giao dich co don gia > 1 ty:");

    boolean timThay = false;

        for (GiaoDich giaoDich : danhSach) {
            if (giaoDich.getDonGia() > 1000000000) {
                System.out.println(giaoDich);
    timThay = true;
            }
        }

        if (!timThay)
{
    System.out.println("Khong co giao dich nao.");
}
    }
}