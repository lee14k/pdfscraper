import PyPDF2

with open('example.pdf', 'rb') as file:
    reader = PyPDF2.PdfFileReader(file)
    num_pages=reader.numPages
    for page_num in range(num_pages):
        page=reader.getPage(page_num)
        text=page.extractText()
        print(f"Content of Page{page_num+1}:\n{text}\n")