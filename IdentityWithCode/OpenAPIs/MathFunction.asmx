

<html>

    <head><link rel="alternate" type="text/xml" href="/MathFunction.asmx?disco" />

    <style type="text/css">
    
		BODY { color: #000000; background-color: white; font-family: Verdana; margin-left: 0px; margin-top: 0px; }
		#content { margin-left: 30px; font-size: .70em; padding-bottom: 2em; }
		A:link { color: #336699; font-weight: bold; text-decoration: underline; }
		A:visited { color: #6699cc; font-weight: bold; text-decoration: underline; }
		A:active { color: #336699; font-weight: bold; text-decoration: underline; }
		A:hover { color: cc3300; font-weight: bold; text-decoration: underline; }
		P { color: #000000; margin-top: 0px; margin-bottom: 12px; font-family: Verdana; }
		pre { background-color: #e5e5cc; padding: 5px; font-family: Courier New; font-size: x-small; margin-top: -5px; border: 1px #f0f0e0 solid; }
		td { color: #000000; font-family: Verdana; font-size: .7em; }
		h2 { font-size: 1.5em; font-weight: bold; margin-top: 25px; margin-bottom: 10px; border-top: 1px solid #003366; margin-left: -15px; color: #003366; }
		h3 { font-size: 1.1em; color: #000000; margin-left: -15px; margin-top: 10px; margin-bottom: 10px; }
		ul { margin-top: 10px; margin-left: 20px; }
		ol { margin-top: 10px; margin-left: 20px; }
		li { margin-top: 10px; color: #000000; }
		font.value { color: darkblue; font: bold; }
		font.key { color: darkgreen; font: bold; }
		font.error { color: darkred; font: bold; }
		.heading1 { color: #ffffff; font-family: Tahoma; font-size: 26px; font-weight: normal; background-color: #003366; margin-top: 0px; margin-bottom: 0px; margin-left: -30px; padding-top: 10px; padding-bottom: 3px; padding-left: 15px; width: 105%; }
		.button { background-color: #dcdcdc; font-family: Verdana; font-size: 1em; border-top: #cccccc 1px solid; border-bottom: #666666 1px solid; border-left: #cccccc 1px solid; border-right: #666666 1px solid; }
		.frmheader { color: #000000; background: #dcdcdc; font-family: Verdana; font-size: .7em; font-weight: normal; border-bottom: 1px solid #dcdcdc; padding-top: 2px; padding-bottom: 2px; }
		.frmtext { font-family: Verdana; font-size: .7em; margin-top: 8px; margin-bottom: 0px; margin-left: 32px; }
		.frmInput { font-family: Verdana; font-size: 1em; }
		.intro { margin-left: -15px; }
           
    </style>

    <title>
	MathFunction Web Hizmeti
</title></head>

  <body>

    <div id="content">

      <p class="heading1">MathFunction</p><br>

      

      <span>

          <p class="intro">A??a????daki i??lemler desteklenmektedir. Tam bir tan??mlama i??in l??tfen <a href="MathFunction.asmx?WSDL">Hizmet Tan??m??n??</a> g??zden ge??irin. </p>
          
          
              <ul>
            
              <li>
                <a href="MathFunction.asmx?op=Control">Control</a>
                
                
              </li>
              <p>
            
              </ul>
            
      </span>

      
      

    <span>
        
    </span>
    
      <span>
          <hr>
          <h3>Bu web hizmeti, varsay??lan ad alan?? olarak http://tempuri.org/ kullan??yor.</h3>
          <h3>??neri: Varsay??lan ad alan??n?? XML Web hizmeti genel kullan??ma a????lmadan ??nce de??i??tirin.</h3>
          <p class="intro">Her XML Web hizmetinin, istemci uygulamalar??n??n kendisini Web ??zerindeki di??er hizmetlerden ay??rt edebilmesi i??in benzersiz bir ad alan?? olmal??d??r. Geli??tirilmekte olan XML Web hizmetleri i??in http://tempuri.org/ adresi kullan??labilir. Ancak yay??mlanm???? XML Web hizmetleri daha kal??c?? bir ad alan?? kullanmal??d??r.</p>
          <p class="intro">XML Web hizmetiniz sizin denetiminizde olan bir ad alan?? taraf??ndan tan??mlanmal??d??r. ??rne??in ??irketinizin Internet etki alan?? ad??n?? ad alan??n??n bir par??as?? olarak kullanabilirsiniz. Pek ??ok XML Web hizmeti ad alan?? URL gibi g??r??nse de, Web ??zerindeki ger??ek kaynaklar?? i??aret etmeleri gerekmez. (XML Web hizmeti ad alanlar??, URI'lerdir.)</p>
          <p class="intro">ASP.NET kullan??larak olu??turulan XML Web hizmetlerinde, varsay??lan ad alan??n?? de??i??tirmek i??in WebService ??zniteli??inin Namespace ??zelli??i kullan??labilir. WebService ??zniteli??i, XML Web hizmeti metotlar??n?? i??eren s??n??f i??in ge??erli bir ??zniteliktir. A??a????da ad alan??n?? "http://microsoft.com/webservices/" olarak belirleyen bir kod ??rne??i g??r??l??yor:</p>
          <p class="intro">C#</p>
          <pre>[WebService(Namespace="http://microsoft.com/webservices/")]
public class MyWebService {
    // uygulama
}</pre>
          <p class="intro">Visual Basic</p>
          <pre>&lt;WebService(Namespace:="http://microsoft.com/webservices/")&gt; Public Class MyWebService
    ' uygulama
End Class</pre>

          <p class="intro">C++</p>
          <pre>[WebService(Namespace="http://microsoft.com/webservices/")]
public ref class MyWebService {
    // uygulama
};</pre>
          <p class="intro">XML ad alanlar?? hakk??nda daha fazla bilgi i??in <a href="http://www.w3.org/TR/REC-xml-names/">XML'de ad alanlar??</A> ile ilgili W3C ??nerilerine bak??n.</p>
          <p class="intro">WSDL konusunda daha fazla bilgi i??in, <a href="http://www.w3.org/TR/wsdl">WSDL Belirtimi'ne</a> bak??n.</p>
          <p class="intro">URI'ler hakk??nda daha fazla bilgi i??in, <a href="http://www.ietf.org/rfc/rfc2396.txt">RFC 2396</a> belgesine bak??n.</p>
      </span>

      

    
  </body>
</html>
