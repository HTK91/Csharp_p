using somersby.tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace somersby.Tools
{
    //LogPath\2020\12\20200502.txt
    //예시

    public enum LogType { Daily, Monthly }


    public class LogManager
    { 
        private string _path;

        #region Constructors
        public LogManager(string path,LogType logType , string prefix, string postfix)
        {
            _path = path;
            _SetLogPath(logType, prefix, postfix);
        }
        //인자 4개 다 들왔을때


        public LogManager(string prefix, string postfix)
            :this(Path.Combine(Application.Root,"Log"),LogType.Daily , prefix , postfix)
        {

        }

        //인자 2개 만 들어왔을때

        public LogManager()
            : this(Path.Combine(Application.Root, "Log"),LogType.Daily,null,null)
        {
        }

        //인자 안들어왔을때

        #endregion


        #region Methods
        private void _SetLogPath(LogType logType, string prefix, string postfix)
        {
            string path = String.Empty;
            string name = String.Empty;


            switch (logType)
            {
                case LogType.Daily:
                    path = String.Format(@"{0}\{1}\", DateTime.Now.Year, DateTime.Now.ToString("MM"));
                    name = DateTime.Now.ToString("yyyyMMdd");
                    break;
                case LogType.Monthly:
                    path = String.Format(@"{0}\", DateTime.Now.Year);
                    name = DateTime.Now.ToString("yyyyMM") ;
                    break;
            }

            //로그 타입 일별 월별

            _path = Path.Combine(_path, path);

            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);

            if (!string.IsNullOrEmpty(prefix))
                name = prefix + name;
            if (!string.IsNullOrEmpty(postfix))
                name = name+ postfix;
            name += ".txt";

            _path = Path.Combine(_path, name);
        }
        //파일 이름 정하는곳

        public void Write(string data)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_path, true))
                {
                    writer.Write(data);
                }
            }
            catch (Exception ex)
            { }
        }

        public void WriteLine(string data)
         {
            try
            {
                using (StreamWriter writer = new StreamWriter(_path, true))
                {
                    writer.WriteLine(DateTime.Now.ToString("yyyyMMdd HH:mm:ss\t") + data);
                }
            }
            catch (Exception ex)
            { }
        }

        #endregion
    }
}
