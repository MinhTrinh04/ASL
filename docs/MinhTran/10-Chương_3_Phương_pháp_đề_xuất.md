# Chương 3: Phương Pháp Đề Xuất

## 3.1 Thiết kế tổng quan hệ thống

### 3.1.1 Tổng quan ứng dụng The VR Labs

**The VR Labs** là một ứng dụng thực tế ảo được phát triển trên nền tảng **Unity**, sử dụng công nghệ **OpenXR** để đảm bảo khả năng tương thích với nhiều loại kính **VR** khác nhau. Ứng dụng này được thiết kế nhằm cung cấp môi trường học tập thực hành tương tác và phong phú, hỗ trợ người học tiếp cận kiến thức và rèn luyện kỹ năng một cách hiệu quả.

Giao diện người dùng của **The VR Labs** được thiết kế theo hướng trực quan và dễ sử dụng, cho phép người học dễ dàng điều hướng giữa các bài giảng, lựa chọn bài giảng thực hành. Ứng dụng tích hợp các tính năng như đánh giá, phản hồi tức thì và hướng dẫn chi tiết, tạo điều kiện cho người học tự đánh giá và cải thiện kỹ năng.

Trong phạm vi của đồ án này, **The VR Labs** tập trung vào hai mục tiêu chính là:
1. **Thực hành kỹ năng:** Cung cấp môi trường thực hành ảo cho các kỹ năng cụ thể trong lĩnh vực công nghệ thông tin, ví dụ như bài giảng **Network Lab** về lắp đặt dây mạng **Ethernet**.
2. **Trò chơi hóa lý thuyết:** Tích hợp các yếu tố trò chơi hóa vào các bài giảng lý thuyết để tăng cường sự hấp dẫn và động lực học tập, như trong bài giảng **Neo Terra** về phát triển bền vững.

Logo của **The VR Labs** (Hình 3.1) là sự kết hợp giữa hình ảnh chiếc mũ tốt nghiệp (biểu tượng của giáo dục) và kính thực tế ảo, thể hiện rõ định hướng ứng dụng công nghệ **VR** vào lĩnh vực giáo dục. Tên gọi **"The VR Labs"** cũng nhấn mạnh ý nghĩa này, tượng trưng cho *"Các phòng thí nghiệm thực tế ảo"*, một không gian học tập sáng tạo và hiện đại, nơi người học có thể trải nghiệm và thực hành trong môi trường mô phỏng chân thực.

> **Hình 3.1:** *Logo của ứng dụng The VR Labs, biểu tượng của sự đổi mới trong giáo dục công nghệ thông tin qua thực tế ảo.*

Trong Hình 3.2, giao diện màn hình khởi đầu của ứng dụng **The VR Labs** được trình bày, nơi người dùng có thể chọn bài giảng thực hành. Giao diện này bao gồm ba lựa chọn chính:
* **Network Lab**
* **Neo Terra**
* **Coming Soon** (chỉ ra sự mở rộng tương lai với các bài giảng mới).

Giao diện này không chỉ là điểm xuất phát cho hành trình học tập mà còn phản ánh sự đa dạng và tiềm năng của **The VR Labs** trong việc cung cấp trải nghiệm giáo dục thực tế ảo.

> **Hình 3.2:** *Giao diện màn khởi đầu lựa chọn bài giảng của The VR Labs.*

### 3.1.2 Công nghệ sử dụng

Ứng dụng **The VR Labs** được phát triển và triển khai dựa trên những công nghệ và thiết bị phần cứng phổ biến, dễ tiếp cận, có tiềm năng giảm bớt công sức cho các nhà phát triển khác khi xây dựng các bài giảng tương tự.

#### Phần mềm và các công cụ chính
* **Unity:** Được lựa chọn làm nền tảng phát triển chính cho ứng dụng **The VR Labs**, không chỉ nhờ vào khả năng tạo ra môi trường **VR** tương tác và hấp dẫn mà còn nhờ vào hệ sinh thái rộng lớn bao gồm các tài nguyên sẵn có và cộng đồng lập trình viên đông đảo. **Unity** được sử dụng để thiết kế giao diện người dùng, xây dựng môi trường **VR**, xử lý tương tác và tích hợp các tính năng đa phương tiện, hỗ trợ đa dạng các ngôn ngữ lập trình, bao gồm **C#**. Điểm mạnh của **Unity** nằm ở khả năng tạo ra các trải nghiệm đồ họa **3D** và **2D** chất lượng cao, cũng như hỗ trợ mạnh mẽ cho việc phát triển trò chơi và ứng dụng tương tác. Thư viện tài nguyên phong phú của **Unity**, bao gồm mô hình, kịch bản, và các hiệu ứng âm thanh, giúp quá trình phát triển trở nên nhanh chóng và hiệu quả.
* **OpenXR:** Để đảm bảo ứng dụng có thể chạy trên nhiều nền tảng phần cứng khác nhau (bao gồm **Pico** và **Oculus Quest**), **OpenXR** - một API đa nền tảng mạnh mẽ, được tích hợp vào **The VR Labs**. Điều này giúp đơn giản hóa quá trình phát triển và triển khai, cho phép ứng dụng tiếp cận được nhiều người dùng hơn với các thiết bị **VR** khác nhau. **OpenXR** không chỉ cung cấp một bộ công cụ thống nhất để tương tác với các thiết bị **VR** mà còn hỗ trợ các tính năng tiên tiến như theo dõi tay, theo dõi mắt và phản hồi xúc giác. Tuy nhiên, do các tính năng này vẫn chưa được phát triển ổn định cho quá trình sử dụng, nên tôi vẫn dùng tay cầm để tương tác với môi trường **VR**.
* **Ngôn ngữ C#:** Được lựa chọn làm ngôn ngữ lập trình chính để phát triển các thành phần logic và tương tác của ứng dụng. **C#** là ngôn ngữ mặc định của **Unity** khi viết các logic xử lý sự kiện, tương tác với các đối tượng trong môi trường **3D**, và xử lý dữ liệu. **C#** được chọn vì tính dễ học, dễ sử dụng, cú pháp rõ ràng và hỗ trợ mạnh mẽ từ cộng đồng lập trình viên, giúp tăng tốc quá trình phát triển và giảm thiểu lỗi phát sinh.
* **Blender:** Một phần mềm mô hình hóa **3D** miễn phí và mã nguồn mở, được sử dụng để tạo ra các mô hình **3D** chi tiết và chân thực, làm phong phú thêm môi trường **VR**. Sau khi được tạo ra, các mô hình này được xuất sang định dạng tương thích với **Unity**, giúp tích hợp mượt mà vào ứng dụng.
* **Meshy AI:** Vì nhà phát triển thường không chuyên thiết kế nên việc sử dụng **Meshy AI**, một công cụ hỗ trợ tạo mô hình **3D** mạnh mẽ, giúp đơn giản hóa quá trình tạo nội dung **3D** cho môi trường **VR**. Công cụ này tận dụng trí tuệ nhân tạo để chuyển đổi hình ảnh **2D** (hoặc văn bản) thành mô hình **3D** chi tiết và chân thực, giảm thiểu đáng kể thời gian và công sức cần thiết để tạo ra các nội dung **3D** phức tạp.
* **Mixamo:** Dịch vụ trực tuyến cung cấp thư viện đa dạng các chuyển động **3D** có thể tùy chỉnh. Dịch vụ này giúp tiết kiệm đáng kể thời gian và công sức trong việc tạo ra các chuyển động phức tạp cho nhân vật và đối tượng trong môi trường **VR**.
* **Gemini 1.5 Pro:** Mô hình ngôn ngữ lớn (LLM) tích hợp nhằm cung cấp khả năng xử lý ngôn ngữ tự nhiên (NLP) cho robot hỗ trợ trong bài giảng **Neo Terra**. **Gemini 1.5 Pro** có khả năng hiểu và phản hồi các câu hỏi của người dùng một cách thông minh và tự nhiên, tạo ra trải nghiệm tương tác chân thực và thú vị. Nhờ đó, robot có thể trả lời các câu hỏi của người dùng về các vật thể trong môi trường ảo, cung cấp thông tin về cách tái chế các vật liệu khác nhau và thậm chí là trò chuyện với người dùng bằng tiếng Pháp.
* **Google Text-to-Speech (TTS):** Một công cụ chuyển đổi văn bản thành giọng nói đã được sử dụng để tạo ra giọng nói cho robot. **Google TTS** hỗ trợ nhiều ngôn ngữ và giọng nói khác nhau, cho phép tùy chỉnh giọng nói của robot sao cho phù hợp với tính cách và ngữ cảnh của bài giảng, đem lại giọng nói tự nhiên và biểu cảm.

#### Thiết bị phần cứng hỗ trợ
* **Pico 4:** Được trang bị chip Qualcomm Snapdragon XR2, RAM 8 GB và bộ nhớ trong lên đến 256 GB, mang đến hiệu năng mạnh mẽ để xử lý đồ họa. Thiết bị sở hữu màn hình LCD độ phân giải 4K+ sắc nét, sống động cùng hệ thống âm thanh không gian 3D tích hợp.
* **Oculus Quest 2:** Được trang bị chip Qualcomm Snapdragon XR2, RAM 6 GB, màn hình LCD gần 2K, hỗ trợ tốc độ làm mới lên đến 120 Hz, mang lại trải nghiệm mượt mà và giảm thiểu hiện tượng giật hình.

Cả hai thiết bị đều hỗ trợ chế độ theo dõi **6DoF (6 bậc tự do)**, cho phép người dùng di chuyển và xoay tự do trong không gian ba chiều, mang lại trải nghiệm học tập **VR** chất lượng cao với **The VR Labs**.

> **Hình 3.3:** *Kính thực tế ảo Pico 4. Nguồn: Pico (2024). [58]*

> **Hình 3.4:** *Kính thực tế ảo Meta Quest 2. Nguồn: Meta (2024). [59]*

---

## 3.2 Thiết kế nội dung bài giảng thực hành Network Lab

Bài giảng thực hành lắp dây mạng - **Network Lab** được phát triển dựa trên nội dung của học phần Mạng máy tính tại **Trường Công nghệ Thông tin và Truyền thông, Đại học Bách khoa Hà Nội**. Bài giảng được thiết kế để mô phỏng chân thực quy trình lắp đặt cáp mạng **Ethernet** trong môi trường thực tế ảo.

Hình 3.5 minh họa ý tưởng chính của bài giảng **Network Lab** trong môi trường **VR**. Hình ảnh này cũng được sử dụng làm giao diện lựa chọn bài giảng trong ứng dụng **The VR Labs**, với logo đặc trưng của trải nghiệm **Network Lab**.

> **Hình 3.5:** *Hình ảnh sử dụng để lựa chọn bài giảng Network Lab với logo của trải nghiệm Network Lab.*

Quy trình thiết kế bài giảng được cấu trúc thành năm giai đoạn chính:
1. **Xác định mục tiêu bài giảng:** Định vị các kiến thức và kỹ năng cụ thể mà người học cần đạt được sau khi hoàn thành bài giảng (Mục 3.2.1).
2. **Thiết kế nội dung bài giảng:** Xây dựng nội dung chi tiết cho bài giảng, bao gồm cả phần lý thuyết và thực hành, đảm bảo tính chính xác, khoa học và phù hợp với môi trường thực tế ảo (Mục 3.2.2).
3. **Giải thích và phân tích lý thuyết:** Trình bày cơ sở lý luận và các lý do dẫn đến việc lựa chọn phương pháp thiết kế bài giảng cụ thể (Chương 4).
4. **Triển khai phát triển phần mềm:** Xây dựng bài giảng trên môi trường thực tế ảo (Chương 5).
5. **Thực hiện khảo sát đánh giá:** Thu thập phản hồi từ người học và đánh giá hiệu quả của bài giảng nhằm cải tiến chất lượng (Chương 5).

### 3.2.1 Xác định mục tiêu bài giảng

Trong bài giảng này, mục tiêu chính là trang bị cho sinh viên những kiến thức và kỹ năng cơ bản về lắp đặt cáp mạng **Ethernet**. Cụ thể, sinh viên sẽ được hướng dẫn để hiểu rõ về các loại cáp mạng và tiêu chuẩn đấu nối đầu cáp với cáp xoắn đôi. Điều này bao gồm việc phân biệt giữa cáp thẳng và cáp chéo, cũng như hiểu rõ ứng dụng của chúng trong thực tế. Bên cạnh đó, một phần quan trọng của bài giảng là việc trau dồi kỹ năng bấm đầu cáp mạng theo tiêu chuẩn, một kỹ năng thiết yếu cho bất kỳ ai làm việc trong lĩnh vực mạng máy tính. Bài giảng được thiết kế để phù hợp với sinh viên năm nhất hoặc năm hai đang theo học các ngành như Công nghệ Thông tin, Điện tử Viễn thông, hoặc các ngành có liên quan.

### 3.2.2 Thiết kế nội dung bài giảng

Trong phần thực hành của bài giảng, người học sẽ được hướng dẫn qua từng bước cụ thể để thực hiện việc lắp đặt cáp mạng như hướng dẫn trong **Bảng 3.1**. Mỗi bước được thực hiện trong môi trường thực tế sẽ tương ứng với các hoạt động được mô phỏng trong môi trường thực tế ảo.

* **Bước 1 (Cắt đoạn cáp mạng):** Người học thực hiện việc cắt một đoạn cáp mạng với chiều dài xác định là 0.5 mét bằng cách sử dụng kìm ảo. Trong môi trường thực tế ảo, người học cần phải lựa chọn chính xác vị trí cắt trên kìm ảo để thực hiện việc cắt cáp mạng một cách chính xác.
* **Bước 2 (Tuốt lớp vỏ cáp):** Người học tiến hành tuốt lớp vỏ bảo vệ của cáp mạng để thấy được các dây đồng bên trong. Trong môi trường **VR**, người dùng cần phải tìm đúng vị trí để tuốt lớp vỏ bên ngoài dây mạng và bấm nút trên tay cầm.
* **Bước 3 (Gỡ xoắn dây mạng):** Trong môi trường thực tế, người học gỡ xoắn và ghép cặp các dây theo màu sắc. Tuy nhiên, trong môi trường thực tế ảo, do giới hạn về khoảng cách tối thiểu giữa hai tay cầm VR khi thực hiện các thao tác nhỏ, việc mô phỏng chi tiết gặp nhiều khó khăn. Vì thế, tôi quyết định thay thế bằng một thao tác bấm nút trong **VR** để gỡ xoắn dây mạng một cách tối ưu.
* **Bước 4 (Sắp xếp dây mạng):** Người học dùng ngón tay giữ và duỗi thẳng các cặp dây, sắp xếp theo thứ tự màu sắc đúng chuẩn. Trong **VR**, người học sẽ sử dụng bộ điều khiển để di chuyển và sắp xếp các dây mạng. Đồng thời, một màn hình hướng dẫn sẽ hiển thị cách sắp xếp đúng để người học dễ dàng ghi nhớ.
* **Bước 5 (Cắt bằng đầu dây và xác nhận):** Trong thực tế, bước này yêu cầu cắt thẳng qua 8 sợi dây để phần dây đồng còn thừa dài khoảng 1.3 cm. Trong môi trường **VR**, để tránh lãng phí thời gian vào thao tác thừa không cần thiết, bước này được thiết kế thành việc cho người dùng thử sai và xác nhận với nút bấm xem mình đã xếp đúng thứ tự dây mạng hay chưa.
* **Bước 6 (Đưa dây vào hạt mạng):** Người học đưa toàn bộ 8 sợi dây đã tuốt vỏ vào hạt mạng (đầu nối mạng). Trong **VR**, người học cầm hạt mạng và đưa dây mạng vào vị trí chính xác, mô phỏng lực ấn mạnh như trong thực tế.
* **Bước 7 (Bấm đầu cáp mạng):** Người học đưa hạt mạng đã nối dây vào vị trí chính xác trên kìm bấm để thực hiện bấm đầu cáp. Trong **VR**, thao tác được thực hiện thông qua nút bấm trên tay cầm.
* **Bước 8 (Hoàn thành quy trình):** Sau khi thực hiện thành công, một thông báo chúc mừng sẽ hiển thị. Người học có thể lựa chọn chơi lại hoặc chọn bài giảng khác.

| STT | Mô tả thực tế | Mô tả bước tương ứng trong VR |
| :---: | :--- | :--- |
| **1** | Sử dụng dụng cụ bấm mạng để cắt một đoạn cáp mạng với chiều dài là 0.5 mét. | Để cắt hẳn dây mạng, cần đặt cáp vào vị trí cắt chính xác trên kìm và bấm cắt bằng tay cầm **VR**. |
| **2** | Sử dụng kìm bấm mạng để tuốt lớp vỏ ngoài của cáp khoảng 2.5cm tính từ một đầu cáp. | Tuốt lớp vỏ ngoài của cáp mô phỏng với chiều dài tương tự. Cần đặt vào đúng vị trí tuốt vỏ dây mạng và bấm nút trên tay cầm **VR**. |
| **3** | Gỡ xoắn và ghép các cặp dây có màu giống nhau. | Chạm vào nút bấm màu xanh trên bàn để gỡ xoắn dây mạng. |
| **4** | Dùng ngón tay giữ và duỗi thẳng các cặp dây, sắp xếp các dây theo màu sắc đúng thứ tự theo loại dây mạng cần lắp đặt. | Sử dụng bộ điều khiển **VR** để gỡ xoắn, ghép cặp và sắp xếp các dây theo màu sắc. Màn hình hướng dẫn sẽ hiển thị cách sắp xếp đúng. |
| **5** | Cắt dây mạng bằng kìm để tạo ra một đoạn dây đồng thẳng, dài khoảng 1,3 cm tính từ điểm cuối của ống bọc nhựa. | Kiểm tra và xác nhận thứ tự dây mạng bằng cách đưa vào nút màu xanh, có thể lặp lại để đảm bảo độ chính xác. |
| **6** | Đưa toàn bộ 8 sợi dây đã tuốt vỏ vào đầu nối, đảm bảo ống bọc nhựa màu xanh nằm hoàn toàn bên trong và dây dẫn chạm đến tận cùng của đầu nối. | Cầm dây mạng và hạt mạng để nối chúng vào với nhau. |
| **7** | Bấm đầu cáp vào hạt mạng bằng kìm: đặt đầu hạt mạng đã được nối dây vào kìm, ấn mạnh để cố định dây. Lưỡi kìm xuyên dây, cố định ống bọc, tạo kết nối chắc chắn. | Cho đầu hạt mạng đã được nối dây mạng vào đúng vị trí ở kìm và thực hiện bấm bằng tay cầm **VR**. |
| **8** | Lặp bước 2-7 cho đầu cáp thứ hai. Đối với cáp chéo, thứ tự màu sắc đầu còn lại khác với thứ tự vừa thực hiện. | Có thể dùng các nút trong thế giới ảo để thực hiện lại các thao tác. |

> **Bảng 3.1:** *Các bước trong thực hành lắp dây mạng.*

Chi tiết phân tích lý thuyết tại sao lại có thiết kế các bước bài giảng như vậy sẽ được trình bày cụ thể tại **Chương 4**.

---

## 3.3 Thiết kế nội dung bài giảng thực hành Neo Terra

**Neo Terra** là một bài giảng thực tế ảo được thiết kế nhằm nâng cao nhận thức về phát triển bền vững, đặc biệt tập trung vào vấn đề phân loại và tái chế rác thải. Bài giảng sử dụng yếu tố **trò chơi hóa (Gamification)** để tạo ra trải nghiệm học tập hấp dẫn và tương tác.

Logo của **Neo Terra** (Hình 3.6) được thiết kế dựa trên ý tưởng về một hành tinh xanh cần được bảo vệ. Hình ảnh quả địa cầu cách điệu với tông màu xanh lá cây chủ đạo tượng trưng cho Trái Đất và thiên nhiên. Biểu tượng kính **VR** được lồng ghép vào hình ảnh quả địa cầu, thể hiện việc ứng dụng công nghệ thực tế ảo vào việc nâng cao nhận thức về môi trường. Chữ "Neo" (mới) và "Terra" (Trái Đất) kết hợp với nhau tạo nên tên gọi **"Neo Terra"**, mang ý nghĩa về một Trái Đất mới, một tương lai bền vững mà chúng ta hướng tới.

> **Hình 3.6:** *Hình ảnh mô tả bài giảng Neo Terra với logo của trò chơi Neo Terra.*

### 3.3.1 Xác định mục tiêu bài giảng

Bài giảng **Neo Terra** được thiết kế với mục tiêu chính là nâng cao nhận thức và hành động của người học về vấn đề phân loại và tái chế rác thải, đồng thời đóng góp vào các **mục tiêu phát triển bền vững của Liên Hợp Quốc**. Bài giảng không chỉ cung cấp kiến thức cơ bản về các loại rác thải và quy trình tái chế mà còn tạo cơ hội cho người học thực hành phân loại rác thải trong môi trường thực tế ảo tương tác. 

Đặc biệt, **Neo Terra** tập trung vào việc đóng góp vào các mục tiêu phát triển bền vững như giáo dục chất lượng, năng lượng sạch, cơ sở hạ tầng bền vững, tiêu dùng và sản xuất có trách nhiệm, hành động vì khí hậu, bảo vệ hệ sinh thái và hợp tác toàn cầu. Ngoài ra, bài giảng còn giúp người học khám phá tiềm năng tái chế của các loại vật liệu và học tiếng Pháp thông qua các hoạt động tương tác trong môi trường **VR**.

### 3.3.2 Thiết kế nội dung bài giảng

**Neo Terra** mở đầu bằng việc đưa người học vào một thế giới tương lai giả tưởng, nơi Trái Đất đang phải đối mặt với những hậu quả nặng nề do thiếu nhận thức về phát triển bền vững. Thông qua cốt truyện hấp dẫn và những thước phim 360 độ chân thực, người học sẽ trực tiếp chứng kiến những tác động tiêu cực đến môi trường, từ đó khơi dậy sự đồng cảm và ý thức trách nhiệm.

Từ nhận thức về vấn đề, bài giảng chuyển sang phần thực hành thông qua trò chơi phân loại rác thải. Đây là một phương pháp giáo dục hiệu quả, giúp người học củng cố kiến thức về các loại rác thải và cách phân loại chúng một cách chính xác. Tính điểm và yếu tố cạnh tranh được lồng ghép vào trò chơi, tạo động lực để người học hoàn thành xuất sắc nhiệm vụ.

Tiếp nối hành trình, người học sẽ được khám phá một thế giới ảo tương tác, nơi họ có thể tìm hiểu về **trí tuệ nhân tạo (AI)** và ứng dụng của nó trong việc tái chế và xử lý rác thải. Thông qua việc tương tác với robot thông minh, người học nhận thức được tiềm năng to lớn của nó trong việc giải quyết các vấn đề môi trường cấp bách.

Cuối cùng, bài giảng còn tích hợp việc học tiếng Pháp thông qua tương tác với robot. Người học có thể khám phá môi trường ảo, trỏ vào các vật thể và tìm hiểu từ vựng tiếng Pháp tương ứng, cùng với nghĩa tiếng Việt và cách phát âm.

Trong bài giảng **Neo Terra**, để tạo trải nghiệm tương tác tốt nhất, người học được trang bị khả năng thực hiện một loạt các thao tác trong môi trường **VR**: di chuyển tự do trong không gian ảo, cầm nắm và di chuyển các vật thể (rác thải), ném rác thải vào đúng thùng để phân loại, và tương tác với các nhân vật khác.

#### Cốt truyện chính
Câu chuyện xoay quanh nhân vật chính **Kael**, một nhà khoa học trẻ tuổi và tài năng, cùng với robot đồng hành **Aethos**. Đặt bối cảnh vào năm 2072, khi Trái Đất đang đối mặt với một thảm họa môi trường nghiêm trọng, bầu khí quyển ô nhiễm nặng nề. Một cơn bão cát dữ dội bất ngờ ập đến, phá hủy nhiều công trình. Trong lúc tìm kiếm nơi trú ẩn, **Kael** và **Aethos** tình cờ lạc vào một hang động cổ xưa, nơi họ tìm thấy **"Lõi Gaia"** – một cổ vật công nghệ bí ẩn của nền văn minh cổ đại, được bảo vệ bởi một hệ thống an ninh tiên tiến. Với sự giúp đỡ của **Aethos**, **Kael** vượt qua các thử thách để chứng minh mình xứng đáng nhận được sự giúp đỡ từ cổ vật này. **Lõi Gaia** truyền một phần năng lượng vào **Aethos**, giúp robot này tiến hóa lên một cấp bậc mới, mạnh mẽ và thông minh hơn. **Kael** quyết định sử dụng **Lõi Gaia** để làm sạch Trái Đất và khôi phục lại vẻ đẹp nguyên sơ của hành tinh.

| Phân cảnh | Kịch bản chi tiết | Thiết kế trong VR |
| :--- | :--- | :--- |
| **Cảnh mở đầu** | Kael choàng tỉnh trong phòng thí nghiệm tối tăm, ánh sáng xanh lập loè. Đầu đau nhức, ký ức mơ hồ. <br>**Kael:** *"Chuyện gì... đã xảy ra...?"* <br>Kael cố gượng dậy. Xung quanh hỗn loạn mảnh vỡ máy móc, dây điện đứt gãy và rác thải công nghiệp ngổn ngang. Robot **Aethos** nằm bất động gần đó, đèn tín hiệu đã tắt. | Phòng thí nghiệm bị tàn phá sau cơn bão cát. Người học sau khi chọn bài giảng **Neo Terra** sẽ được đưa vào phân cảnh này. |
| **Tìm thấy giải pháp** | Kael lục lọi xung quanh, chạm tay vào một mảnh giấy cũ kỹ: *"Hồi sinh từ đống tro tàn, tìm thấy ánh sáng trong bóng tối."* Ký ức ùa về về một dự án nghiên cứu đầy tham vọng, một nguồn năng lượng mới và một tiếng nổ lớn... | Một chiếc bàn với cuốn sách mở có hiệu ứng gợi ý màu xanh. Sau khi thao tác, thông báo hiện lên để người chơi đồng ý. Một phòng xem video hiện lên tái hiện ký ức làm tiền đề cho cốt truyện. |
| **Màn chơi 1: Phân loại rác thải** | *"Đúng rồi... công nghệ tái chế năng lượng... Aethos!"* Kael cẩn thận nâng robot lên đặt vào bệ năng lượng duy nhất còn hoạt động. Cỗ máy phân loại và tái chế rác khổng lồ vẫn sừng sững. Kael buộc phải đứng từ xa ném các mảnh rác vào đúng vị trí phân loại nhằm tái tạo năng lượng kịp lúc cho Aethos. Kael nhớ lại cách phân loại và thực hiện ném rác. Năng lượng dần đạt đến 100%. | Người chơi thực hiện nhiệm vụ ném rác trong căn phòng đổ nát. Người chơi có thể bấm nút xem video hướng dẫn phân loại rác (60 giây). Màn hình tính điểm hiển thị, nếu ném hết rác mà chưa đạt 100% thì cần chơi lại. Khi đạt 100%, **Aethos** thức tỉnh. |
| **Màn chơi 2: Aethos thức tỉnh** | *"Aethos, cậu đã tỉnh rồi!"* Kael hỏi han Aethos về thảm hoạ thế giới và cơ chế tái chế rác thành năng lượng. Kael nhận ra thế giới mới sử dụng ngôn ngữ khác. Aethos trấn an: *"Đừng lo, Kael. Tôi sẽ giúp cậu hiểu thêm về ngôn ngữ thế giới này."* | Người chơi trỏ vào vật thể trong môi trường để tìm hiểu khả năng tái chế rác thải thông qua robot, hoặc chọn chức năng học từ vựng tiếng Pháp tương ứng. |

> **Bảng 3.2:** *Kịch bản bài giảng Neo Terra.*

---

## 3.4 Mô hình hoá yêu cầu

Đồ án thực hiện mô hình hóa các yêu cầu đã phân tích thông qua các biểu đồ ca sử dụng (Use Case Diagram) và biểu đồ hoạt động (Activity Diagram). Trong hệ thống **The VR Labs**, tác nhân chính (Actor) là **Người học**.

### 3.4.1 Biểu đồ ca sử dụng tổng quan

Biểu đồ ca sử dụng tổng quan được trình bày trong **Hình 3.7** mô tả các tương tác chính giữa người học và hệ thống **The VR Labs**. Ba ca sử dụng chính bao gồm *"Chọn bài giảng"*, *"Trải nghiệm Network Lab"* và *"Trải nghiệm Neo Terra"*. Ca sử dụng *"Trải nghiệm lại bài học"* mở rộng (extend) từ hai ca sử dụng trên, cho phép người học thử lại các bài giảng nhiều lần.

> **Hình 3.7:** *Biểu đồ ca sử dụng của hệ thống The VR Labs.*

### 3.4.2 Biểu đồ ca sử dụng phân rã

Hình 3.8 mô tả các ca sử dụng phân rã của bài giảng **Network Lab**, trong đó người học được hướng dẫn cách lắp đặt cáp mạng **Ethernet** từ việc gỡ xoắn dây, phân loại dây mạng, cắt dây mạng, nối dây mạng và bấm đầu cáp mạng.

> **Hình 3.8:** *Biểu đồ ca sử dụng của bài giảng Network Lab.*

Hình 3.9 mô tả các ca sử dụng phân rã của bài giảng **Neo Terra**, trong đó người học được hướng dẫn cách phân loại rác thải, xem video hướng dẫn, học từ vựng tiếng Pháp và tìm hiểu khả năng tái chế rác thông qua tương tác với robot thông minh.

> **Hình 3.9:** *Biểu đồ ca sử dụng của bài giảng Neo Terra.*

### 3.4.3 Biểu đồ hoạt động

Biểu đồ hoạt động trình bày trong **Hình 3.10** thể hiện luồng hoạt động chi tiết của toàn bộ hệ thống từ việc khởi động, lựa chọn bài giảng, thực hiện các thao tác bài học, ghi nhận kết quả và trải nghiệm lại, giúp quá trình lập trình hệ thống được rõ ràng và chuẩn xác.

> **Hình 3.10:** *Biểu đồ hoạt động của The VR Labs.*
