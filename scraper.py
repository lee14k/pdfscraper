import PyPDF2

with open('example.PDF', 'rb') as file:
    reader = PyPDF2.PdfReader(file)
    num_pages=len(reader.pages)
    for page_num in range(num_pages):
        page=reader.pages[page_num]
        text=page.extract_text()
        print(f"Content of Page{page_num+1}:\n{text}\n")