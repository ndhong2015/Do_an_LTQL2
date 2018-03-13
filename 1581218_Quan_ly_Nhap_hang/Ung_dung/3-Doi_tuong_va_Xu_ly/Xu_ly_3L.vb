Imports System.IO
Imports Newtonsoft.Json

' Hổ trợ Học tập/Giảng dạy theo phương pháp PET 
' PET  Phiên bản 3.0 - Tháng 1/2018
' Giáo viên 
' Nguyễn tiến Huy
'**************** Xử lý Thể hiện *******************
Public Class XL_THE_HIEN
    Public Shared Dinh_dang_VN = System.Globalization.CultureInfo.GetCultureInfo("vi-VN")

    Public Sub Xuat_Hinh(Ma_so As String, Th As ToolStripItem)
        Dim Nhi_phan = New XL_LUU_TRU().Doc_Nhi_phan_Hinh(Ma_so)
        Dim Luong As New IO.MemoryStream(Nhi_phan)
        Th.Image = Bitmap.FromStream(Luong)

    End Sub
    Public Sub Xuat_Hinh(Ma_so As String, Kich_thuoc As Size, Th As Button)
        Th.Size = Kich_thuoc
        Dim Nhi_phan = New XL_LUU_TRU().Doc_Nhi_phan_Hinh(Ma_so)
        Dim Luong As New IO.MemoryStream(Nhi_phan)
        Th.BackgroundImage = Image.FromStream(Luong)
        Th.BackgroundImageLayout = ImageLayout.Stretch

    End Sub
    Public Function Tao_The_hien_Hinh(Ma_so As String, Kich_thuoc As Size) As Button
        Dim Th As New Button
        Th.Size = Kich_thuoc
        Dim Nhi_phan = New XL_LUU_TRU().Doc_Nhi_phan_Hinh(Ma_so)
        Dim Luong As New IO.MemoryStream(Nhi_phan)
        Th.BackgroundImage = Image.FromStream(Luong)
        Th.BackgroundImageLayout = ImageLayout.Stretch
        Return Th
    End Function
End Class
'**************** Xử lý Nghiệp vụ  *******************
Public Class XL_NGHIEP_VU
    Public Function Tra_cuu_Tivi(Chuoi_Tra_cuu As String, Danh_sach_Tivi As List(Of XL_TIVI)) As List(Of XL_TIVI)
        Chuoi_Tra_cuu = Chuoi_Tra_cuu.ToUpper
        Dim Danh_sach = Danh_sach_Tivi.FindAll(
            Function(Tivi)
                Return Tivi.Ten.ToString.ToUpper.Contains(Chuoi_Tra_cuu)
            End Function)
        Return Danh_sach
    End Function
    Public Function Tinh_So_luong_Ton_Tivi(Tivi As XL_TIVI) As Long
        Dim Tong_Ban = Tivi.Danh_sach_Ban_hang.Sum(Function(Ban_hang) Ban_hang.So_luong)
        Dim Tong_Nhap = Tivi.Danh_sach_Nhap_hang.Sum(Function(Ban_hang) Ban_hang.So_luong)
        Return Tong_Nhap - Tong_Ban
    End Function
    Public Function Tinh_So_luong_Ton_Nhom_Tivi(Nhom_Tivi As XL_NHOM_TIVI, Du_lieu As XL_DU_LIEU) As Long
        Dim Danh_sach_Tivi_cua_Nhom_Tivi = Du_lieu.Danh_sach_Tivi.FindAll(Function(Tivi) Tivi.Nhom_Tivi.Ma_so = Nhom_Tivi.Ma_so)
        Dim So_luong_Ton = Danh_sach_Tivi_cua_Nhom_Tivi.Sum(Function(Tivi) Tinh_So_luong_Ton_Tivi(Tivi))
        Return So_luong_Ton
    End Function
End Class
'**************** Xử lý  Lưu trữ *******************
Public Class XL_LUU_TRU

    Dim Thu_muc_Debug As DirectoryInfo = New DirectoryInfo(Application.StartupPath)
    Dim Thu_muc_Project As DirectoryInfo = Thu_muc_Debug.Parent.Parent

    Dim Thu_muc_Du_lieu As DirectoryInfo = Thu_muc_Project.Parent.Parent.GetDirectories("2-Du_lieu_Luu_tru")(0)
    Dim Thu_muc_Cua_hang As DirectoryInfo = Thu_muc_Du_lieu.GetDirectories("Cua_hang")(0)
    Dim Thu_muc_Tivi As DirectoryInfo = Thu_muc_Du_lieu.GetDirectories("Tivi")(0)

    Dim Thu_muc_Media As DirectoryInfo = Thu_muc_Project.Parent.Parent.GetDirectories("Media")(0)
    Dim Kieu_Hinh As String = ".png"
#Region "Xử lý Đọc"

    Public Function Doc_Du_lieu() As XL_DU_LIEU ' Chưa xử lý Caching
        Dim Kq As New XL_DU_LIEU
        Kq.Cua_hang = Doc_Danh_sach_Cua_hang()(0)
        Kq.Danh_sach_Tivi = Doc_Danh_sach_Tivi()
        Return Kq
    End Function
    Function Doc_Danh_sach_Cua_hang() As List(Of XL_CUA_HANG)
        Dim Danh_sach As New List(Of XL_CUA_HANG)
        Thu_muc_Cua_hang.GetFiles("*.json").ToList.ForEach(
            Sub(Tap_tin)
                Dim Chuoi_JSON = File.ReadAllText(Tap_tin.FullName)
                Dim Cua_hang = JsonConvert.DeserializeObject(Of XL_CUA_HANG)(Chuoi_JSON)
                Danh_sach.Add(Cua_hang)
            End Sub)
        Return Danh_sach
    End Function
    Function Doc_Danh_sach_Tivi() As List(Of XL_TIVI)
        Dim Danh_sach As New List(Of XL_TIVI)
        Thu_muc_Tivi.GetFiles("*.json").ToList.ForEach(
            Sub(Tap_tin)
                Dim Chuoi_JSON = File.ReadAllText(Tap_tin.FullName)
                Dim Cua_hang = JsonConvert.DeserializeObject(Of XL_TIVI)(Chuoi_JSON)
                Danh_sach.Add(Cua_hang)
            End Sub)
        Return Danh_sach
    End Function
    Public Function Doc_Nhi_phan_Hinh(Ma_so As String) As Byte()
        Dim Kq As Byte()
        Dim Duong_dan = Thu_muc_Media.FullName & "\" & Ma_so & Kieu_Hinh
        Kq = System.IO.File.ReadAllBytes(Duong_dan)
        Return Kq
    End Function
#End Region

#Region "Xử lý Ghi"
    Public Function Cap_nhat_Don_gia_Nhap_Tivi(Tivi As XL_TIVI, Don_gia_Nhap_Moi As Long) As String
        Dim Kq As String = ""
        Dim Don_gia_Nhap_Hien_nay = Tivi.Don_gia_Nhap
        Tivi.Don_gia_Nhap = Don_gia_Nhap_Moi
        Try
            Dim Duong_dan = Thu_muc_Tivi.FullName & "\" & Tivi.Ma_so & ".json"
            Dim Chuoi_JSON = JsonConvert.SerializeObject(Tivi)
            File.WriteAllText(Duong_dan, Chuoi_JSON)
            Kq = "OK"
        Catch Loi As Exception
            Kq = Loi.Message
        End Try
        If Kq <> "OK" Then
            Tivi.Don_gia_Nhap = Don_gia_Nhap_Hien_nay
        End If
        Return Kq
    End Function
#End Region




End Class
