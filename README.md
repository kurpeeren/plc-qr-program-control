# BARIDA GROUP Staj Projesi: QR Kod Tabanlı Otomasyon Sistemi

Bu proje, BARIDA GROUP staj süresi boyunca Recep Arslan ve Eren Kürpe tarafından geliştirilmiş bir otomasyon sistemini tanıtmaktadır. Bu sistemde QR kodlar kullanılarak komutlar 14 byte'lık veriler halinde çözülmüş ve bu veriler PLC'ye gönderilerek komutların gerçekleştirilmesi sağlanmıştır. Proje kapsamında Siemens S7-1200 PLC, Siemens V90 servo sürücü ve bir adet valf entegre edilmiştir.

## Proje Detayları

Bu projede, bir otomasyon sistemi geliştirdik. Sistem, QR kodlarla iletilen komutları alarak PLC üzerinde işlenmekte ve bu komutlara göre belirli aksiyonları gerçekleştirmektedir. Projede temel olarak aşağıdaki bileşenler kullanılmıştır:

- **Siemens S7-1200 PLC:** QR kodlardan alınan verilerin işlendiği ve aksiyonların yürütüldüğü ana kontrol birimi.
- **Siemens V90 Servo Sürücü:** Servo motorun hareketini kontrol etmek için kullanılan sürücü.
- **Valf:** Sistemde kullanılan valf, belirli akışları kontrol etmek için entegre edilmiştir.
- **C# Arayüz:** Görüntü işleme için C# dilinde geliştirilmiş bir arayüz. Bu arayüz, QR kodlarını okuyarak verileri çözümleyip PLC'ye iletmektedir.

Projede iki ana mod bulunmaktadır: Manuel ve Otomatik. Manuel modda servo motorun ve valfin belirli hareketleri kontrol edilebilmektedir. Otomatik modda ise önceden belirlenmiş çalışma algoritmaları ile hareket edilmektedir.

Projemiz, endüstriyel otomasyonun ve görüntü işlemenin birleşimi ile farklı bir perspektif sunmaktadır. Ayrıntılı teknik bilgiler ve kod örnekleri için GitHub deposuna göz atabilirsiniz.


## Çalışma Videosu

Projenin çalışma prensibini daha iyi anlamak için aşağıdaki YouTube videosunu izleyebilirsiniz:

[![Projeyi İzle](https://img.youtube.com/vi/YE_kuHe7W9A/0.jpg)](https://www.youtube.com/watch?v=YE_kuHe7W9A)


## Proje Faydaları

Bu proje, dinamik programlama ve çeşitli kamera çözümlerini bir araya getirerek bir dizi ek fayda sunmaktadır:

1. **Çeşitli Kamera Seçenekleri:** Proje, düşük maliyetli webcam kameraları veya farklı kamera çözümleriyle entegre çalışabilme yeteneğine sahiptir. Ürünün üzerinden veya ürün taşıyıcısı üzerinden okunan QR kodlarına göre çeşitli işlemleri esnek bir şekilde ayarlayabilir.

2. **Dinamik Görevler:** Sistem, QR kodları içerisine gömülmüş veya program özelliklerine göre belirlenen kodlara göre dinamik görevler yerine getirebilme yeteneğine sahiptir. Bu sayede farklı işlem senaryolarını hızla uygulayabilir ve iş süreçlerini optimize edebilirsiniz.

3. **Veriye Dayalı İşlem:** QR kodlar, verileri taşıyarak programların ve işlemlerin dinamik olarak değiştirilmesini sağlar. Bu, ürünlerin türüne veya özelliklerine göre özelleştirilmiş işlemleri gerçekleştirmenizi mümkün kılar.

4. **Hız ve Esneklik:** Çeşitli kamera seçenekleri ve dinamik programlama, hızlı ve esnek bir şekilde işlemlerin yapılmasını sağlar. Ürünlerin seri üretiminde veya farklı senaryolarda hızlı tepki verme ve işlemleri uyarlayabilme yeteneği sağlar.

5. **Yüksek Verimlilik:** Dinamik görevler ve esnek kamera seçenekleri, iş süreçlerinin daha verimli hale gelmesini sağlar. Otomatik program değişimi sayesinde verileri hızla işleyebilir ve üretkenliği artırabilirsiniz.

Bu proje, ürünlerin farklı senaryolarda dinamik bir şekilde işlenmesi ve programların esnek bir şekilde ayarlanması için bir örnek sunar. İş süreçlerini optimize etmek ve verimliliği artırmak isteyenler için değerli bir çözümdür.
