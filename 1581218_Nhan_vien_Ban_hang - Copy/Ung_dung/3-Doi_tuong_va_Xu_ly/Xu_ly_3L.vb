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
    Public Function Tra_cuu_San_pham(Chuoi_Tra_cuu As String, Danh_sach_San_pham As List(Of XL_SAN_PHAM)) As List(Of XL_SAN_PHAM)
        Chuoi_Tra_cuu = Chuoi_Tra_cuu.ToUpper
        Dim Danh_sach = Danh_sach_San_pham.FindAll(
            Function(San_pham)
                Return San_pham.Ten.ToString.ToUpper.Contains(Chuoi_Tra_cuu)
            End Function)
        Return Danh_sach
    End Function
    Public Function Tinh_Doanh_thu_Ngay_Hien_hanh_San_pham(San_pham As XL_SAN_PHAM) As Long
        Dim Ngay_Hien_hanh = DateTime.Today
        Dim Danh_sach_Ban_hang_cua_Ngay_Hien_hanh = San_pham.Danh_sach_Ban_hang.FindAll(
            Function(Ban_hang) Ban_hang.Ngay.Day = Ngay_Hien_hanh.Day _
                                    AndAlso Ban_hang.Ngay.Month = Ngay_Hien_hanh.Month _
                                    AndAlso Ban_hang.Ngay.Year = Ngay_Hien_hanh.Year)
        Dim Doanh_thu = Danh_sach_Ban_hang_cua_Ngay_Hien_hanh.Sum(Function(Ban_hang) Ban_hang.Tien)
        Return Doanh_thu
    End Function
End Class
'**************** Xử lý  Lưu trữ *******************
Public Class XL_LUU_TRU

    Dim Thu_muc_Debug As DirectoryInfo = New DirectoryInfo(Application.StartupPath)
    Dim Thu_muc_Project As DirectoryInfo = Thu_muc_Debug.Parent.Parent

    Dim Thu_muc_Du_lieu As DirectoryInfo = Thu_muc_Project.Parent.Parent.GetDirectories("2-Du_lieu_Luu_tru")(0)
    Dim Thu_muc_Cua_hang As DirectoryInfo = Thu_muc_Du_lieu.GetDirectories("Cua_hang")(0)
    Dim Thu_muc_San_pham As DirectoryInfo = Thu_muc_Du_lieu.GetDirectories("San_pham")(0)

    Dim Thu_muc_Media As DirectoryInfo = Thu_muc_Project.Parent.Parent.GetDirectories("Media")(0)
    Dim Kieu_Hinh As String = ".jpg"
#Region "Xử lý Đọc"

    Public Function Doc_Du_lieu() As XL_DU_LIEU ' Chưa xử lý Caching
        Dim Kq As New XL_DU_LIEU
        Kq.Cua_hang = Doc_Danh_sach_Cua_hang()(0)
        Kq.Danh_sach_San_pham = Doc_Danh_sach_San_pham()
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
    Function Doc_Danh_sach_San_pham() As List(Of XL_SAN_PHAM)
        Dim Danh_sach As New List(Of XL_SAN_PHAM)
        Thu_muc_San_pham.GetFiles("*.json").ToList.ForEach(
            Sub(Tap_tin)
                Dim Chuoi_JSON = File.ReadAllText(Tap_tin.FullName)
                Dim San_pham = JsonConvert.DeserializeObject(Of XL_SAN_PHAM)(Chuoi_JSON)
                Danh_sach.Add(San_pham)
            End Sub)
        Return Danh_sach
    End Function
    Public Function Doc_Nhi_phan_Hinh(Ma_so As String) As Byte()
        Dim Kq As Byte()
        If Ma_so.Contains("NV") Or Ma_so.Contains("PET") Then
            Kieu_Hinh = ".png"
        End If
        Dim Duong_dan = Thu_muc_Media.FullName & "\" & Ma_so & Kieu_Hinh
        Kq = System.IO.File.ReadAllBytes(Duong_dan)
        Return Kq
    End Function
#End Region

#Region "Xử lý Ghi"
    Public Function Ghi_Ban_hang_Moi(San_pham As XL_SAN_PHAM, Ban_hang As XL_BAN_HANG) As String
        Dim Kq As String = ""
        San_pham.Danh_sach_Ban_hang.Add(Ban_hang)
        Try
            Dim Duong_dan = Thu_muc_San_pham.FullName & "\" & San_pham.Ma_so & ".json"
            Dim Chuoi_JSON = JsonConvert.SerializeObject(San_pham)
            File.WriteAllText(Duong_dan, Chuoi_JSON)
            Kq = "OK"
        Catch Loi As Exception
            Kq = Loi.Message
        End Try
        If Kq <> "OK" Then
            San_pham.Danh_sach_Ban_hang.Remove(Ban_hang)
        End If
        Return Kq
    End Function
#End Region




End Class
