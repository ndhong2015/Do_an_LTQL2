'**************** Cấu trúc các biến Đối tượng khi Lập trình *******************
Public Class XL_CHUC_NANG
    Public Ten, Ma_so As String
End Class
'****** Đối tượng CSDL Du_lieu
Public Class XL_DU_LIEU
    Public Cua_hang As New XL_CUA_HANG ' Tổ chức 
    Public Danh_sach_Tivi As New List(Of XL_TIVI) ' Đối tượng Quản lý chính 
End Class
'****** Đối tượng Tổ chức Cua_hang
Public Class XL_CUA_HANG
    Public Ten, Ma_so As String
    Public Danh_sach_Nhom_Tivi As New List(Of XL_NHOM_TIVI)
    Public Danh_sach_Nhan_vien_Nhap_hang As New List(Of XL_NHAN_VIEN_NHAP_HANG)
    Public Danh_sach_Quan_ly_Nhap_hang As New List(Of XL_QUAN_LY_NHAP_HANG)
    Public Danh_sach_Quan_ly_Ban_hang As New List(Of XL_QUAN_LY_BAN_HANG)
End Class
'****** Các Đối tượng Con người,Phân loại theo Nhóm
Public Class XL_NHOM_TIVI
    Public Ten, Ma_so As String
End Class
Public Class XL_NHAN_VIEN_NHAP_HANG
    Public Ho_ten, Ma_so, Ten_Dang_nhap, Mat_khau As String
End Class
Public Class XL_QUAN_LY_NHAP_HANG
    Public Ho_ten, Ma_so, Ten_Dang_nhap, Mat_khau As String
End Class
Public Class XL_NHAN_VIEN_BAN_HANG
    Public Ho_ten, Ma_so, Ten_Dang_nhap, Mat_khau As String
    Public Danh_sach_Nhom_Tivi As New List(Of XL_NHOM_TIVI)
End Class
Public Class XL_QUAN_LY_BAN_HANG
    Public Ho_ten, Ma_so, Ten_Dang_nhap, Mat_khau As String
End Class
Public Class XL_QUAN_LY_CUA_HANG
    Public Ho_ten, Ma_so, Ten_Dang_nhap, Mat_khau As String
End Class

'****** Đối tượng Quản lý Chính 
Public Class XL_TIVI
    Public Ten, Ma_so As String
    Public Don_gia_Nhap, Don_gia_Ban As Long
    Public Nhom_Tivi As New XL_NHOM_TIVI()
    Public Danh_sach_Nhap_hang As New List(Of XL_NHAP_HANG)
    Public Danh_sach_Ban_hang As New List(Of XL_BAN_HANG)
End Class
'****** Các Đối tượng Hoạt động 
Public Class XL_NHAP_HANG
    Public Ngay As DateTime = DateTime.Today
    Public Don_gia, So_luong, Tien As Long
End Class
Public Class XL_BAN_HANG
    Public Ngay As DateTime = DateTime.Today
    Public Don_gia, So_luong, Tien As Long
End Class

