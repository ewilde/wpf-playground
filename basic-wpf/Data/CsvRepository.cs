namespace basic.wpf.Data
{
    using System.Collections.Generic;
    using System.IO;

    using basic_wpf.Data;

    using CsvHelper;
    using CsvHelper.Configuration;

    public class CsvRepository<TModel> : IRepository<TModel>
    {
        private readonly CsvReader csvReader;

        public CsvConfiguration CsvConfiguration  { get; set; }

        public string DataFilePath { get; set; }

        public CsvRepository(string dataFilePath)
        {
            this.DataFilePath = dataFilePath;
            if (!File.Exists(dataFilePath))
            {
                throw new FileNotFoundException(string.Format("Data file for the csv repository not found {0}.", Path.GetFullPath(dataFilePath)), dataFilePath);
            }

            this.CsvConfiguration = new CsvConfiguration { HasHeaderRecord = true };
            this.csvReader = new CsvReader(new StreamReader(this.DataFilePath), this.CsvConfiguration);
        }

        public IEnumerable<TModel> GetAll()
        {
            return this.csvReader.GetRecords<TModel>();
        }
    }
}
