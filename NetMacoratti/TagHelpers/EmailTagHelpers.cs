using Microsoft.AspNetCore.Razor.TagHelpers;

namespace NetMacoratti.TagHelpers
{
    public class EmailTagHelpers: TagHelper
    {      

        public String Endereco { get; set; }
        public String  Conteudo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:" + Endereco);
            output.Content.SetContent(Conteudo);
        }
    }
}
