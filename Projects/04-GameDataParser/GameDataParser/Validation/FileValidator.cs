namespace GameDataParser.Validation
{
    public class FileValidator : IFileValiadtor
    {
        public bool Validate(string fileName)
        {
            
            if (fileName is null) throw new ArgumentNullException("File name cannot be null! ");

            if (fileName == string.Empty) throw new InvalidOperationException("File name cannot be empty! ");

            if (!File.Exists(fileName)) throw new FileNotFoundException("File not found! ");
        
            return true;
        }
    }
}
