
< 짱도 HTML 컨바터 >

설명:
  Chrome 확장도구(Snappy Snippet)로 획득한 특정 엘리먼트의 HTML, CSS 코드를
  HTML, PDF, JPEG 형식으로 저장해주는 기능 사용

사용법:
  Chrome 실행 → F12(개발자 도구) → Snappy Snippet → HTML, CSS 복사 후 이 프로그램에 붙여넣기


사용한 라이브러리:
 - sixlabors-imagesharp v2.1.3
 - pdfiumviewer v2.13.0.0
 - pdfsharp-wpf v1.50.5147
 - newtonsoft-json 2.0.3
 - materialdesigncolors v2.0.6
 - materialdesignthemes v4.5.0
 - htmlrenderer (내장) v1.5.1.0
   -> htmlrenderer 라이브러리에서 pdfsharp 라이브러리를 구버전으로 사용하고 있어서
      assembly ambiguous 때문에 최신 pdfsharp와 htmlrenderer를 동시에 사용할 수가 없었다.
      그래서 오픈소스 코드를 가져와서 직접 내 프로젝트에 포함시킨 후 pdfsharp 버전을 맞춰줬다.


