'**************** Cấu trúc các biến Đối tượng khi Lập trình *******************
'****** Đối tượng CSDL Du_lieu
Public Class XL_DU_LIEU
    Public Cua_hang As New XL_CUA_HANG ' Tổ chức 
    Public Danh_sach_San_pham As New List(Of XL_SAN_PHAM) ' Đối tượng Quản lý chính
    Public Danh_sach_Phieu_dat As New List(Of XL_DAT_HANG) ' Đối tượng Quản lý chính
End Class
'****** Đối tượng Tổ chức Cua_hang
Public Class XL_CUA_HANG
    Public Ten, Ma_so, Dien_thoai, Dia_chi, Mail As String
    Public Danh_sach_Nhom_San_pham As New List(Of XL_NHOM_SAN_PHAM)
    Public Danh_sach_Nhan_vien_Ban_hang As New List(Of XL_NHAN_VIEN_BAN_HANG)
    Public Danh_sach_Khach_tham_quan As New List(Of XL_KHACH_THAM_QUAN)
End Class
'****** Các Đối tượng Con người,Phân loại theo Nhóm
Public Class XL_NHOM_SAN_PHAM
    Public Ten, Ma_so As String
    Public Phan_loai As New List(Of XL_PHAN_LOAI)
End Class
Public Class XL_PHAN_LOAI
    Public Ten, Ma_so As String
End Class
Public Class XL_KHACH_THAM_QUAN
    Public Ho_ten, Ma_so, Ten_Dang_nhap, Mat_khau As String
End Class
Public Class XL_KHACH_HANG
    Public Ho_ten, Ma_so, Dien_thoai, Mail, Dia_chi As String
End Class
Public Class XL_NHAN_VIEN_NHAP_HANG
    Public Ho_ten, Ma_so, Ten_Dang_nhap, Mat_khau As String
End Class
Public Class XL_QUAN_LY_NHAP_HANG
    Public Ho_ten, Ma_so, Ten_Dang_nhap, Mat_khau As String
End Class
Public Class XL_NHAN_VIEN_BAN_HANG
    Public Ho_ten, Ma_so, Ten_Dang_nhap, Mat_khau As String
    Public Danh_sach_Nhom_San_pham As New List(Of XL_NHOM_SAN_PHAM)
End Class
Public Class XL_QUAN_LY_BAN_HANG
    Public Ho_ten, Ma_so, Ten_Dang_nhap, Mat_khau As String
End Class
Public Class XL_NHAN_VIEN_GIAO_HANG
    Public Ho_ten, Ma_so, Ten_Dang_nhap, Mat_khau As String
End Class
Public Class XL_QUAN_LY_GIAO_HANG
    Public Ho_ten, Ma_so, Ten_Dang_nhap, Mat_khau As String
End Class
Public Class XL_QUAN_LY_CUA_HANG
    Public Ho_ten, Ma_so, Ten_Dang_nhap, Mat_khau As String
End Class

'****** Đối tượng Quản lý Chính 
Public Class XL_SAN_PHAM
    Public Ten, Ma_so As String
    Public Don_gia_Ban As Long
    Public Don_gia_Nhap As Long
    Public Nhom_San_pham As New XL_NHOM_SAN_PHAM()
    Public Danh_sach_Nhap_hang As New List(Of XL_NHAP_HANG)
    Public Danh_sach_Ban_hang As New List(Of XL_BAN_HANG)
    Public Danh_sach_Dat_hang As New List(Of XL_DAT_HANG)
    Public So_luong As Long
End Class

'****** Các Đối tượng Hoạt động 
Public Class XL_NHAP_HANG
    Public Ngay As DateTime = DateTime.Today
    Public Don_gia, So_luong, Tien As Long
End Class
Public Class XL_BAN_HANG
    Public Ho_ten_Khach_hang, Ho_ten_Nhan_vien, Dia_chi, Dien_thoai, Mail As String
    Public Ngay As DateTime = DateTime.Today
    Public Don_gia, So_luong, Tien As Long
End Class
Public Class XL_DAT_HANG
    Public Ma_so As String
    Public Ngay_dat As DateTime = DateTime.Today
    Public Ngay_giao As DateTime = DateTime.Today
    Public Trang_thai As String
    Public Khach_hang As XL_KHACH_HANG
    Public Danh_sach_San_pham As List(Of XL_SAN_PHAM_DAT_HANG)
End Class
Public Class XL_SAN_PHAM_DAT_HANG
    Public Ma_so, Ten As String
    Public Don_gia, So_luong, Tien As Long
End Class
'Public Class XL_GIAO_HANG
'    Public Ma_so, Trang_thai, Ho_ten_Khach_hang, Ho_ten_Nhan_vien, Dia_chi, Dien_thoai, Mail As String
'    Public Danh_sach_San_pham As List(Of XL_SAN_PHAM)
'    Public Ngay As DateTime = DateTime.Today
'    Public Don_gia, So_luong, Tien As Long
'End Class

