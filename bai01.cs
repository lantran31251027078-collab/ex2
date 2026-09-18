package bai01;

import java.util.ArrayList;

/**
 * Lop cha mo ta thong tin chung cua mot chuyen xe.
 */
class ChuyenXe
{
    protected String maSoChuyen;
    protected String hoTenTaiXe;
    protected String soXe;
    protected double doanhThu;

    public ChuyenXe(String maSoChuyen, String hoTenTaiXe,
                    String soXe, double doanhThu)
    {
        this.maSoChuyen = maSoChuyen;
        this.hoTenTaiXe = hoTenTaiXe;
        this.soXe = soXe;
        this.doanhThu = doanhThu;
    }

    public double getDoanhThu()
    {
        return doanhThu;
    }
}

/**
 * Lop mo ta chuyen xe noi thanh.
 */
class ChuyenXeNoiThanh extends ChuyenXe
{
    private int soTuyen;
private double soKm;

public ChuyenXeNoiThanh(String maSoChuyen, String hoTenTaiXe,
                        String soXe, int soTuyen,
                        double soKm, double doanhThu)
{
    super(maSoChuyen, hoTenTaiXe, soXe, doanhThu);
    this.soTuyen = soTuyen;
    this.soKm = soKm;
}
}

/**
 * Lop mo ta chuyen xe ngoai thanh.
 */
class ChuyenXeNgoaiThanh extends ChuyenXe
{
    private String noiDen;
private int soNgay;

public ChuyenXeNgoaiThanh(String maSoChuyen, String hoTenTaiXe,
                          String soXe, String noiDen,
                          int soNgay, double doanhThu)
{
    super(maSoChuyen, hoTenTaiXe, soXe, doanhThu);
    this.noiDen = noiDen;
    this.soNgay = soNgay;
}
}

/**
 * Lop chay chuong trinh quan ly chuyen xe.
 */
public class Main
{
    public static void main(String[] args)
    {

        // Tao danh sach chuyen xe
        ArrayList<ChuyenXe> danhSach = new ArrayList<>();

        // Tao 2 chuyen xe noi thanh
        danhSach.add(new ChuyenXeNoiThanh(
                "NT01", "Nguyen Van An", "51A-12345",
                10, 120, 500000
        ));

        danhSach.add(new ChuyenXeNoiThanh(
                "NT02", "Tran Van Binh", "51A-23456",
                15, 150, 600000
        ));

        // Tao 2 chuyen xe ngoai thanh
        danhSach.add(new ChuyenXeNgoaiThanh(
                "NG01", "Le Van Cuong", "51B-11111",
                "Da Lat", 3, 3000000
        ));

        danhSach.add(new ChuyenXeNgoaiThanh(
                "NG02", "Pham Van Dung", "51B-22222",
                "Vung Tau", 2, 2000000
        ));

        double tongDoanhThu = 0;
        double tongDoanhThuNoiThanh = 0;
        double tongDoanhThuNgoaiThanh = 0;

        // Tinh doanh thu
        for (ChuyenXe xe : danhSach)
        {

            tongDoanhThu += xe.getDoanhThu();

            if (xe instanceof ChuyenXeNoiThanh) {
            tongDoanhThuNoiThanh += xe.getDoanhThu();
        }

        if (xe instanceof ChuyenXeNgoaiThanh) {
            tongDoanhThuNgoaiThanh += xe.getDoanhThu();
        }
    }

    // Xuat ket qua
    System.out.println("Tong doanh thu tat ca chuyen xe: "
                + tongDoanhThu);

    System.out.println("Tong doanh thu chuyen xe noi thanh: "
                + tongDoanhThuNoiThanh);

    System.out.println("Tong doanh thu chuyen xe ngoai thanh: "
                + tongDoanhThuNgoaiThanh);
}
}