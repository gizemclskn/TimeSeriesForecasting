Zaman Serisi Tahmini

Bu proje, zaman serisi analizi kullanarak hava yolu şirketinin aylık yolcu sayılarını tahmin etmek için bir model oluşturur. Model, geçmiş ayların verilerini kullanarak gelecekteki yolcu sayılarını tahmin etmek için kullanılır.

Veri Seti

Bu proje, hava yolu şirketinin aylık yolcu sayılarını içeren bir CSV dosyası kullanmaktadır. Veri seti, aşağıdaki özelliklere sahiptir:

- Ay (Month): Ayların sayısal temsili
- Yolcu Sayısı (Passengers): Her aydaki toplam yolcu sayısı

Model

Model, Microsoft ML.NET kütüphanesi kullanılarak oluşturulmuştur. SSA (Singular Spectrum Analysis) algoritması kullanılarak zaman serisi tahmini yapılır. Model eğitilirken, geçmiş ayların verileri kullanılarak gelecekteki yolcu sayısı tahmin edilir.
