using Learning.HomeWorks;

const string localhost = "localhost";
const string vvcard = "vvcard.ru";
const string vk = "vk.ru";
const string sayTo = "saytkotorogo.net";
const string google = "google.com"; 
const string facebook = "facebook.com";
const string linkedin = "linkedin.com";
const string modem = "192.168.0.1";


var addresses = new string[] { localhost,vvcard, vk, sayTo, google, facebook, linkedin, modem };

var siteReq = new ThreadSiteRequesHomeWork();
siteReq.Run(addresses);











Console.ReadLine();

