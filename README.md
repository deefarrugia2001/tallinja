# Malta Public Transport
<p align="center">
  <img src="http://www.maltapagina.nl/pic/transportmaltalogo.jpg"/>
</p>

<h2>What's the big deal?</h2>
<p align="justify">This project uses Selenium web scraping library in order to fetch the balance of the Malta Public Transport card upon from the Check Balance section within the company's website. Once the customer number is provided (fetch the IWebElement with the ID corresponding to the text field, then use the SendKeys method to type the customer number input by the user/fetched from the database accordingly) and the Submit is programmatically clicked (you would first need to fetch the IWebElement with the ID corresponding to the submit button). Once the balance is fetched, the database will contain the history of when the user requested the balance check. The balance may also be validated accordingly.</p>

<p align="justify">Software being used thus far includes Microsoft Visual Studio Community 2019 IDE, Microsoft SQL Management Studio v18, as well as GitHub Desktop. Although there is no deadline as this is a solo project, I believe using GitHub will allow me to work more productively as I usually set a goal to spread a specific number of commits on a daily basis, thus lessening the chance of procrastination (hopefully at least). Ultimately the aim of this project is to depict an understanding of object-oriented programming, as well as three-tier architecture and data storage. The project is currently stored on a private repository on GitHub.</p>

<p>It's not much but hey, everyone starts somewhere, right?</p>
