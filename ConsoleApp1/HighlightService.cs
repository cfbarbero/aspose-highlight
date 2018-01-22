using Aspose.Pdf;
using Aspose.Pdf.Text;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class HighlightService
    {
        public int Highlight(Document pdfDocument, List<string> highlightPhrases)
        {
            int highlights = 0;
            TextFragmentAbsorber textAbsorder;

            foreach (string higlightPhrase in highlightPhrases)
            {
                textAbsorder = new TextFragmentAbsorber("(?i)" + higlightPhrase, new TextSearchOptions(true));
                TextFragmentCollection txtFragmentCollection = textAbsorder.TextFragments;
                pdfDocument.Pages.Accept(textAbsorder);

                highlights += txtFragmentCollection.Count;
                foreach (TextFragment tf in txtFragmentCollection)
                {
                    tf.TextState.BackgroundColor = Color.Yellow;
                }
            }

            return highlights;
        }
    }
}
