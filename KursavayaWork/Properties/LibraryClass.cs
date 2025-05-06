using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursavayaWork.Properties
{
    /// <summary>
    /// Класс, предназначенный для работы с изменением размера текста
    /// </summary>
    public class TextRedactor
    {
        public static Font TxtRedactor(float Wdth, float Hght, Font textic, float sizer)
        {
            float baseFontSize = sizer;
            float scaleFactor = 5.98f * (float)Math.Pow(Math.Sqrt(Wdth * Hght), 0.75) / 853f;
            float newFontSize = baseFontSize * scaleFactor;
            Font returner = new Font(textic.FontFamily, newFontSize, style: FontStyle.Bold);
            return returner;
        }
        public static Point LocationChange(int x, int y, float  chang, int metric, float Wdth, float Hght)
        {
            float koefchange = (float)Math.Sqrt(Wdth * Hght) * 0.0014f - 1.076f;
            int change = (int)(chang * koefchange);
            if (metric == 1)
            { return new Point(x, y + change); }
            else
            { return new Point(x + change, y); }
        }
    }
    /// <summary>
    /// Класс, предназначенный для работы с датами
    /// </summary>
    public class TimeDataWork
    {
        /// <summary>
        /// Переводит дату из строчного типа в массив чисел.
        /// Возвращает массив чисел (день, месяц, год)
        /// </summary>
        /// <param name="datamo">Дата
        /// должно быть задано датой формата ДД.ММ.ГГГГ, типа string</param>
        /// returns>Массив чисел</returns>
        public static int[] DataNumerousCollector(string datamo)
        {
            int[] datatrue = new int[3];
            string[] datasplt = datamo.Split('.');
            for (int i = 0; i < 3; i++)
            {
                datatrue[i] = int.Parse(datasplt[i]);
            }
            return datatrue;
        }
        /// <summary>
        /// Проверяет отношение первой даты со второй
        /// Возвращает числа 0, 1 или 2 (0 - даты равны, 1 - дата1 более новая, 2 - дата1 более старая)
        /// </summary>
        /// <param name="data1">Первая дата
        /// должно быть задано массивом из 3-х чисел, формата (день, месяц, год), типа int[]</param>
        /// <param name="datasravn">Вторая дата
        /// должно быть задано массивом из 3-х чисел, формата (день, месяц, год), типа int[]</param>
        /// returns>0, 1 или 2</returns>
        public static int IsDataFarther(int[] data1, int[] datasravn)
        {
            int result = 0;
            for (int i = 2; i >= 0; i--)
            {
                if (data1[i] < datasravn[i])
                {
                    result = 2;
                    break;
                }
                else if (data1[i] > datasravn[i])
                {
                    result = 1;
                    break;
                }
            }
            return result;
        }
    }
    public class Massive
    {
        /// <summary>
        /// Функция, для определения читаемого файла (1)
        /// Возвращает файл в формате StreamReader
        /// </summary>
        /// <param name="file">Номер файла
        /// должно быть задано целым неотрицательным числом, типа int</param>
        /// <param name="Griva">Вывод списка
        /// returns>список файлов в формате FileInfo[]</returns>
        public static FileInfo[] WhodAFile(DataGridView Griva)
        {
            DirectoryInfo Dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] AllFiles = Dir.GetFiles("*.txt");
            Griva.Rows.Clear();
            if (AllFiles.Length == 0)
            { /*Console.WriteLine("В каталоге не обнаружен не один файл формата txt");*/ }
            else
            {
                for (int i = 0; i < AllFiles.Length; i++)
                {
                    Griva.Rows.Add(i+1, AllFiles[i]);
                }
            }
            return AllFiles;
        }
        /// <summary>
        /// Функция, для определения читаемого файла (2)
        /// Возвращает файл в формате StreamReader
        /// </summary>
        /// <param name="file">Номер файла
        /// должно быть задано целым неотрицательным числом, типа int</param>
        /// <param name="AllFiles">Список файлов
        /// returns>файл в формате StreamReader</returns>
        public static StreamReader ChooseAFile(int file, FileInfo[] AllFiles)
        {
            if (file == 0)
            {
                StreamReader Reader = new StreamReader("StartList.txt");
                return Reader;
            }
            else
            {
                StreamReader Reader = new StreamReader(AllFiles[file - 1].Name);
                return Reader;
            }
        }
        /// <summary>
        /// Превращение читаемого файла в список кортежей
        /// Возвращает список кортежей (номер, имя файла, дата, кол-во обращений)
        /// </summary>
        /// <param name="Reader">Читаемый файл
        /// должно быть задано файлом, типа StreamReader</param>
        /// returns>список кортежей</returns>
        public static List<(int, string, string, int)> FileStartReading(int file, StreamReader Reader)
        {
            List<(int, string, string, int)> Files = new List<(int, string, string, int)>();
            int num = 0;
            string stroka = "";
            do
            {
                num++;
                stroka = Reader.ReadLine();
                string[] strokalst = stroka.Split(' ');
                Files.Add((num, strokalst[0], strokalst[1], int.Parse(strokalst[2])));
            } while (!Reader.EndOfStream);
            Reader.Close();
            return Files;
        }
        /// <summary>
        /// Соединяет существующий список с читаемым файлом, в формате списка кортежей
        /// Возвращает список кортежей (номер, имя файла, дата, кол-во обращений)
        /// </summary>
        /// <param name="Files">Список кортежей
        /// должно быть задано списком кортежей, формата (номер, имя файла, дата, кол-во обращений), типа List<(int, string, string, int)></param>
        /// <param name="Reader">Читаемый файл
        /// должно быть задано файлом, типа StreamReader</param>
        /// returns>список кортежей</returns>
        public static List<(int, string, string, int)> FileAddingReading(List<(int, string, string, int)> Files, StreamReader Reader)
        {
            int lenght = Files.Count;
            int num = 0;
            string stroka = "";
            do
            {
                num++;
                stroka = Reader.ReadLine();
                string[] strokalst = stroka.Split(' ');
                Files.Add((num + lenght, strokalst[0], strokalst[1], int.Parse(strokalst[2])));
            } while (!Reader.EndOfStream);
            Reader.Close();
            return Files;
        }
        /// <summary>
        /// Превращает список кортежей в файл, сохраняет файл по пути: <НазваниеПроекта>\<НазваниеПроекта>\bin\Debug
        /// </summary>
        /// <param name="Filess">Список кортежей
        /// должно быть задано списком кортежей, формата (номер, имя файла, дата, кол-во обращений), типа List<(int, string, string, int)></param>
        /// <param name="name">Название сохраняемого файла
        /// должно быть задано строкой, типа string</param>
        public static void FileWritting(List<(int, string, string, int)> Filess, string name)
        {
            File.Create(name + ".txt").Close();
            using (StreamWriter Writer = new StreamWriter(name + ".txt"))
                for (int i = 0; i < Filess.Count; i++)
                { Writer.WriteLine(Filess[i].Item2 + " " + Filess[i].Item3 + " " + Filess[i].Item4); }
        }
        /// <summary>
        /// Добавляет в существующий список новый элемент, после/перед определенным элементом
        /// Возвращает список кортежей (номер, имя файла, дата, кол-во обращений)
        /// </summary>
        /// <param name="Files">Список кортежей
        /// должно быть задано списком кортежей, формата (номер, имя файла, дата, кол-во обращений), типа List<(int, string, string, int)></param>
        /// <param name="numero">Номер элемента после/перед которым записываем новый элемент
        /// должно быть задано неотрицательным целым числом, типа int</param>
        /// <param name="direction">Направление (1 - Перед элементом, 2 - После)
        /// должно быть задано числом 1 или 2, типа int</param>
        /// <param name="name">Имя файла нового элемента
        /// должно быть задано строкой, типа string</param>
        /// <param name="data">Имя файла нового элемента
        /// должно быть задано датой формата ДД.ММ.ГГГГ, типа string</param>
        /// <param name="count">Количество обращений нового элемента
        /// должно быть задано неотрицательным целым числом, типа int</param>
        /// returns>список кортежей</returns>
        public static List<(int, string, string, int)> AddingFiles(List<(int, string, string, int)> Files, int numero, int direction, string name, string data, int count)
        {
            List<(int, string, string, int)> FilesNew = new List<(int, string, string, int)>();
            int L = 0; 
            if (direction == 1) { L = -1; }
            int k = 0;
            for (int i = 0; i < Files.Count; i++)
            {
                if (i == numero + L)
                {
                    FilesNew.Add((i + 1, name, data, count)); k++;
                    FilesNew.Add((Files[i].Item1 + k, Files[i].Item2, Files[i].Item3, Files[i].Item4));
                }
                else
                { FilesNew.Add((Files[i].Item1 + k, Files[i].Item2, Files[i].Item3, Files[i].Item4)); }
            }
            return FilesNew;
        }
        /// <summary>
        /// Удаляет из существующего списка все элементы, дата которых ниже введенной
        /// Возвращает список кортежей (номер, имя файла, дата, кол-во обращений)
        /// </summary>
        /// <param name="Files">Список кортежей
        /// должно быть задано списком кортежей, формата (номер, имя файла, дата, кол-во обращений), типа List<(int, string, string, int)></param>
        /// <param name="datamo">Дата
        /// должно быть задано датой формата ДД.ММ.ГГГГ, типа string</param>
        /// returns>список кортежей</returns>
        public static List<(int, string, string, int)> RemovingFilesForDato(List<(int, string, string, int)> Files, string datamo)
        {
            int[] trdata = TimeDataWork.DataNumerousCollector(datamo);
            List<(int, string, string, int)> FilesNew = new List<(int, string, string, int)>();
            int k = 0;
            for (int i = 0; i < Files.Count; i++)
            {
                int[] datava = TimeDataWork.DataNumerousCollector(Files[i].Item3);
                if (TimeDataWork.IsDataFarther(datava, trdata) == 1)
                { FilesNew.Add((Files[i].Item1 - k, Files[i].Item2, Files[i].Item3, Files[i].Item4)); }
                else
                { k++; }
            }
            return FilesNew;
        }
        /// <summary>
        /// Оставляет из существующего списка все элементы, дата которых входит в диапозон из двух дат
        /// Возвращает список кортежей (номер, имя файла, дата, кол-во обращений)
        /// </summary>
        /// <param name="Files">Список кортежей
        /// должно быть задано списком кортежей, формата (номер, имя файла, дата, кол-во обращений), типа List<(int, string, string, int)></param>
        /// <param name="data1">Начальная дата
        /// должно быть задано датой формата ДД.ММ.ГГГГ, типа string</param>
        /// <param name="data2">Конечная дата
        /// должно быть задано датой формата ДД.ММ.ГГГГ, типа string</param>
        /// returns>список кортежей</returns>
        public static List<(int, string, string, int)> DataFromPeriod(List<(int, string, string, int)> Files, string data1, string data2)
        {
            int[] data1true = TimeDataWork.DataNumerousCollector(data1);
            int[] data2true = TimeDataWork.DataNumerousCollector(data2);
            List<(int, string, string, int)> FilesNew = new List<(int, string, string, int)>();
            int k = 0;
            for (int i = 0; i < Files.Count; i++)
            {
                int[] datava = TimeDataWork.DataNumerousCollector(Files[i].Item3);
                if (TimeDataWork.IsDataFarther(datava, data1true) == 1 && TimeDataWork.IsDataFarther(datava, data2true) == 2)
                { FilesNew.Add((Files[i].Item1 - k, Files[i].Item2, Files[i].Item3, Files[i].Item4)); }
                else
                { k++; }
            }
            return FilesNew;
        }
        /// <summary>
        /// Сортирует существующий список по именам
        /// Возвращает список кортежей (номер, имя файла, дата, кол-во обращений)
        /// </summary>
        /// <param name="Files">Список кортежей
        /// должно быть задано списком кортежей, формата (номер, имя файла, дата, кол-во обращений), типа List<(int, string, string, int)></param>
        /// returns>список кортежей</returns>
        public static List<(int, string, string, int)> FilesSortNames(List<(int, string, string, int)> Files)
        {
            List<(int, string, string, int)> FilesNew = new List<(int, string, string, int)>();
            FilesNew = Files.OrderBy(x => x.Item2).ToList().GetRange(0, Files.Count);
            for (int i = 0; i < FilesNew.Count; i++)
            { FilesNew[i] = (i+1, FilesNew[i].Item2, FilesNew[i].Item3, FilesNew[i].Item4); }
            return FilesNew;
        }
        /// <summary>
        /// Оставляет определенное количество элементов с наибольшим количеством обращений из существующего списка 
        /// Возвращает список кортежей (номер, имя файла, дата, кол-во обращений)
        /// </summary>
        /// <param name="Files">Список кортежей
        /// должно быть задано списком кортежей, формата (номер, имя файла, дата, кол-во обращений), типа List<(int, string, string, int)></param>
        /// <param name="kolvo">Определенное количество
        /// должно быть задано натуральным числом, типа int</param>
        /// returns>список кортежей</returns>
        public static List<(int, string, string, int)> FindManyFilesMaxCount(List<(int, string, string, int)> Files, int kolvo)
        {
            List<(int, string, string, int)> FilesNew = new List<(int, string, string, int)>();
            FilesNew = Files.OrderByDescending(x => x.Item4).ToList().GetRange(0, kolvo);
            for (int i = 0; i < FilesNew.Count; i++)
            { FilesNew[i] = (i + 1, FilesNew[i].Item2, FilesNew[i].Item3, FilesNew[i].Item4); }
            return FilesNew;
        }
        /// <summary>
        /// Оставляет из существующего списка только те элементы, которые начинаются на определенную последовательность символов
        /// Возвращает список кортежей (номер, имя файла, дата, кол-во обращений)
        /// </summary>
        /// <param name="Files">Список кортежей
        /// должно быть задано списком кортежей, формата (номер, имя файла, дата, кол-во обращений), типа List<(int, string, string, int)></param>
        /// <param name="litra">Определенная последовательность символов
        /// должно быть задано строкой, типа string</param>
        /// returns>список кортежей</returns>
        public static List<(int, string, string, int)> FindManyFilesOnLitter(List<(int, string, string, int)> Files, string litra)
        {
            List<(int, string, string, int)> FilesNew = new List<(int, string, string, int)>();
            for (int i = 0; i < Files.Count; i++)
            {
                int ind = 1;
                for (int j = 0; j < litra.Length; j++)
                {
                    if (Files[i].Item2[j] != litra[j])
                    { ind = 0; }
                }
                if (ind == 1)
                { FilesNew.Add(Files[i]); }
            }
            if (FilesNew.Count == 0)
            { return null; }
            else
            { return FilesNew; }
        }
    }
}
