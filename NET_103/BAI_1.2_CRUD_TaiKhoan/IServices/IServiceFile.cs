using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1._2_CRUD_TaiKhoan.IServices
{
    public interface IServiceFile
    {
        //1. Phương thức lưu File
        string saveFile<T>(string path, T lstTemp);
        //2. Phương thức đọc File
        List<T> openFile<T>(string path);
    }
}
