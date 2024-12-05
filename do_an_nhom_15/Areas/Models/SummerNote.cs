namespace do_an_nhom_15.Areas.admin.Models
{
    public class SummerNote(string idEditor, bool loadLibrary = true)
    {
        public string IDEditor { get; set; } = idEditor;
        public bool LoadLibrary { get; set; } = loadLibrary;
        public int Height { set; get; } = 500;
        public string toolBar { set; get; } = @"
        [
            ['style',['style']],
            ['font',['bold','underline','clear']],
            ['color',['color']],
            ['para',['ul','ol','paragraph']],
            ['table',['table']],
            ['insert',['link','elfinderFiles','video','elfinder']],
            ['view',['fullscreen','codeview','help']]

        ]";
    }
}