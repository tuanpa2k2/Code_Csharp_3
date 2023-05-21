using BAI_1._2_CRUD_TaiKhoan.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1._2_CRUD_TaiKhoan.Services
{
    class ServiceFile : IServiceFile
    {
        private FileStream _fs;
        private BinaryFormatter _bf;
        public List<T> openFile<T>(string path)
        {
            try
            {
                List<T> lstData = new List<T>();
                _fs = new FileStream(path, FileMode.Open);
                _bf = new BinaryFormatter();
                var data = _bf.Deserialize(_fs);
                lstData = new List<T>();
                lstData = (List<T>)data;
                _fs.Close();
                return lstData;
            }
            catch (Exception)
            {
                _fs.Close();
                return null;
            }
        }

        public string saveFile<T>(string path, T lstTemp)
        {
            try
            {
                _fs = new FileStream(path, FileMode.Create);
                _bf = new BinaryFormatter();
                _bf.Serialize(_fs, lstTemp);
                _fs.Close();
                return "Ghi File thành công !";
            }
            catch (Exception e)
            {
                _fs.Close();
                Console.WriteLine(e);
                return "Ghi File thất bại !";
            }
        }
    }
}
