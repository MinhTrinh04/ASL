# Chương 5: Đánh Giá Thực Nghiệm

Chương 4 đã trình bày chi tiết về nền tảng lý thuyết làm cơ sở cho việc thiết kế và phát triển hệ thống **The VR Labs**, bao gồm các lý thuyết học tập như học tập trải nghiệm, học tập qua thử và sai, thuyết thất bại sản xuất, thuyết tự quyết, thuyết tải nhận thức và lý thuyết trò chơi hóa. Việc áp dụng các lý thuyết này không chỉ giúp tối ưu hóa trải nghiệm học tập của người dùng mà còn tạo ra một môi trường học tập tương tác, hấp dẫn và hiệu quả.

Tiếp nối những phân tích lý thuyết này, **Chương 5** sẽ tập trung vào việc đánh giá thực nghiệm hệ thống **The VR Labs**. Thông qua việc thiết kế chi tiết hệ thống, triển khai thử nghiệm và thu thập dữ liệu từ người dùng, chương này sẽ đánh giá một cách khách quan tính hiệu quả của **The VR Labs** trong việc nâng cao chất lượng giáo dục thực hành.

## 5.1 Tổng quan thực nghiệm

Nghiên cứu tập trung vào hai bài giảng thực hành là **Network Lab** (mô phỏng quy trình lắp đặt cáp mạng Ethernet) và **Neo Terra** (bài giảng nâng cao nhận thức về phát triển bền vững thông qua trò chơi hóa).

Nghiên cứu được thực hiện với **47 học viên** từ nhiều bối cảnh khác nhau. Các học viên được trải nghiệm **Network Lab** và **Neo Terra** theo thứ tự. Dữ liệu được thu thập thông qua phương pháp kết hợp định lượng và định tính: khảo sát theo thang đo **Likert 5 mức độ** và phỏng vấn bán cấu trúc (semi-structured interview).

Kết quả nghiên cứu cung cấp cái nhìn khách quan về tác động của công nghệ **VR** đến việc học tập thực hành, đồng thời làm cơ sở khoa học cho việc cải tiến hệ thống trong tương lai.

## 5.2 Triển khai hệ thống thực tế

### 5.2.1 Giao diện và thiết kế 3D trong The VR Labs

Trong quá trình phát triển **The VR Labs**, các giao diện cho môi trường học tập ảo được thiết kế tỉ mỉ. 
* Hình phác thảo 5.1 và giao diện thực tế 5.2 thể hiện giao diện màn hình chính của ứng dụng, nơi người dùng bắt đầu hành trình và chọn lựa bài học.
* Hình 5.3 và 5.4 cho thấy bản phác thảo ý tưởng giao diện cho hai bài giảng chính **Network Lab** và **Neo Terra**.
* Giao diện thực tế được triển khai hoàn chỉnh trong môi trường **VR** được thể hiện qua Hình 5.5 và 5.6.

> **Hình 5.1:** *Phác thảo giao diện chính của The VR Labs.*

> **Hình 5.2:** *Giao diện đã triển khai trong môi trường VR.*

> **Hình 5.3:** *Phác thảo giao diện cho bài giảng Network Lab.*

> **Hình 5.4:** *Phác thảo giao diện cho bài giảng Neo Terra.*

> **Hình 5.5:** *Giao diện đã triển khai cho bài giảng Network Lab.*

> **Hình 5.6:** *Giao diện đã triển khai cho bài giảng Neo Terra.*

#### Thiết kế vật thể 3D trong Network Lab
* **Kìm bấm mạng (Hình 5.7):** Được mô phỏng với đầy đủ chức năng tương ứng ngoài đời thực bao gồm: lưỡi dao lớn để cắt đứt dây mạng, lưỡi dao tuốt để cắt lớp vỏ bảo vệ bên ngoài, và phần rãnh kìm để ép lưỡi đồng của hạt mạng tiếp xúc với lõi dây đồng bên trong.
* **Dây mạng (Hình 5.8):** Thể hiện rõ hai trạng thái: chưa gỡ xoắn (các cặp dây xoắn chặt với nhau gọn gàng) và đã gỡ xoắn (các lõi dây đồng màu sắc đa dạng được tách rời sẵn sàng cho việc sắp xếp màu sắc theo chuẩn A hoặc B).

> **Hình 5.7:** *Thiết kế kìm bấm mạng trong Network Lab.*

> **Hình 5.8:** *Thiết kế kìm dây mạng trong Network Lab.*

#### Thiết kế nhân vật và thùng rác trong Neo Terra
Quy trình thiết kế nhân vật 3D trong môi trường thực tế ảo với sự hỗ trợ của trí tuệ nhân tạo được trình bày chi tiết tại Hình 5.9:
1. Người dùng cung cấp ý tưởng thiết kế nhân vật cho AI dưới dạng văn bản (Prompt).
2. AI (**Meshy AI**) tự động tạo ra mô hình 3D thô kèm bề mặt chất liệu (Texture).
3. Tinh chỉnh chi tiết mô hình 3D trong phần mềm **Blender**.
4. Chỉnh sửa chi tiết texture bằng công nghệ đồ họa **Canva**.
5. Tích hợp khung xương chuyển động (Rigging) và gán hoạt ảnh (Animation) thông qua **Mixamo** và **Unity**.
6. Kiểm thử hoạt động thực tế trong game.

> **Hình 5.9:** *Quy trình thiết kế nhân vật 3D trong môi trường thực tế ảo với sự hỗ trợ của AI.*

* **Nhân vật Kael (Hình 5.10):** Thiết kế dáng đứng chữ T, phong cách hoạt hình thân thiện, mặc áo blouse trắng biểu trưng cho nhà nghiên cứu khoa học trẻ - *"người bảo vệ mạnh mẽ"* của hành tinh.
* **Robot Aethos (Hình 5.11):** Robot đồng hành nhỏ nhắn, màu trắng xanh thân thiện, được trang bị màn hình hiển thị và cánh tay robot đa năng.
* **Thùng rác phân loại (Hình 5.12):** Sử dụng một mô hình 3D gốc nhưng được phủ các chất liệu màu sắc (Material) khác nhau kèm biểu tượng trực quan để đại diện cho các nhóm rác thải: rác hữu cơ, rác tái chế, rác vô cơ.

> **Hình 5.10:** *Thiết kế Kael - Nhân vật chính.*

> **Hình 5.11:** *Thiết kế Aethos - Robot đồng hành.*

> **Hình 5.12:** *Thiết kế thùng rác trong Neo Terra.*

### 5.2.2 Các module phần mềm có khả năng tái sử dụng

Để hỗ trợ phát triển các bài giảng thực tế ảo tương tự một cách nhanh chóng, tôi đã xây dựng các module độc lập có khả năng tái sử dụng cao:

1. **Input Manager (Hình 5.13):** Module nền tảng cấu hình môi trường **VR** cơ bản (VR Origin, bàn tay ảo và cấu hình tương tác). Thao tác cầm nắm được kế thừa từ nghiên cứu của nhóm **BKVerse** tại **EdTech Center, Đại học Bách khoa Hà Nội** [60].
2. **Audio Text Manager (Hình 5.14):** Xử lý đồng bộ hóa tự động giữa file âm thanh hướng dẫn, nội dung văn bản hiển thị trên bảng thông tin và hoạt ảnh cử chỉ của robot hướng dẫn theo tuần tự logic của bài học.
3. **Aethos Controller (Hình 5.15):** Quản lý toàn bộ trạng thái hoạt động của robot thông qua mô hình toán học **máy trạng thái hữu hạn (FSM)**. Module cho phép cấu hình trực quan trong Unity Inspector các thuộc tính di chuyển (Navmesh Agent), hoạt ảnh (Animator), giọng nói (TTS Module), và nhận diện vật thể (Scan Module).
4. **Gemini Module (Hình 5.16):** Xử lý nhận dạng hình ảnh camera trong game bằng mô hình **Gemini 1.5 Pro**, tạo ra câu trả lời thông minh dựa trên prompt tùy chỉnh, sau đó chuyển hóa thành giọng nói thông qua **Google Text-to-Speech** phát trực tiếp trong thế giới ảo.

> **Hình 5.13:** *Module InputManager.*

> **Hình 5.14:** *Module AudioTextManager.*

> **Hình 5.15:** *Module AethosController.*

> **Hình 5.16:** *Gemini Module.*

### 5.2.3 Quá trình triển khai và lịch sử khảo sát

* **Tháng 4/2023:** Trình bày khung lý thuyết đề tài *"Đề xuất giải pháp nâng cao chất lượng giảng dạy thực hành ứng dụng công nghệ thực tế ảo"* tại **Hội nghị Sinh viên Nghiên cứu khoa học lần thứ 40** (Trường CNTT&TT, ĐHBK Hà Nội). Poster trình bày được thể hiện tại Hình 5.17.
* **Tháng 6/2023:** Triển lãm và lấy ý kiến trải nghiệm thực tế bài giảng **Network Lab** tại ĐHBK Hà Nội (Hình 5.18). Hướng dẫn sử dụng được cung cấp qua poster ở Hình 5.19.
* **Tháng 6/2024:** Thuyết trình bản thử nghiệm **Neo Terra** tại cuộc thi **Hackathon** của **Tổ chức Quốc tế Pháp ngữ (OIF)** và lọt vào top 10 thế giới dự chung kết tại Bucharest, Romania (Hình 5.20) [17].
* **Tháng 6/2024:** Triển khai phiên bản hoàn chỉnh của **The VR Labs** trên kính **Pico 4** và **Meta Quest 2**, thực hiện khảo sát toàn diện trên 48 người học với sự tham gia của **TS. Nguyễn An Hưng**, giảng viên phụ trách Thực hành Mạng máy tính (Hình 5.21).

> **Hình 5.17:** *Poster trình bày đề tài tại Hội nghị Sinh viên Nghiên cứu khoa học lần thứ 40.*

> **Hình 5.18:** *Buổi triển lãm về bài giảng Network Lab tại Trường Công nghệ Thông tin và Truyền thông, Đại học Bách khoa Hà Nội, tháng 6/2023.*

> **Hình 5.19:** *Poster hướng dẫn sử dụng ứng dụng Network Lab.*

> **Hình 5.20:** *Trình bày ý tưởng và một phần chương trình Neo Terra tại cuộc thi do Tổ chức Quốc tế Pháp ngữ tổ chức [17].*

> **Hình 5.21:** *Hình ảnh buổi khảo sát ứng dụng The VR Labs dưới sự tham gia góp ý của giảng viên vào tháng 6/2024.*

---

## 5.3 Phân tích dữ liệu khảo sát thực nghiệm

### 5.3.1 Phương pháp thu thập dữ liệu và công thức đánh giá

Khảo sát sử dụng phương pháp nghiên cứu hỗn hợp (Mixed-methods):
* **Định lượng:** Thang Likert 5 điểm (1: Hoàn toàn không đồng ý, 5: Hoàn toàn đồng ý) khảo sát mức độ tự tin, năng lực tiếp thu.
* **Định tính:** Phỏng vấn bán cấu trúc thu thập cảm nhận sâu sắc của người học.

Độ tin cậy của thang đo được tính toán khoa học thông qua **hệ số Cronbach's alpha ($\alpha$)**:

$$\alpha = \frac{k}{k - 1} \left( 1 - \frac{\sum_{i=1}^{k} \text{Var}(X_i)}{\text{Var}(X_{\text{total}})} \right)$$

Trong đó:
* $k$: Số lượng câu hỏi khảo sát.
* $\text{Var}(X_i)$: Phương sai của câu hỏi thứ $i$.
* $\text{Var}(X_{\text{total}})$: Phương sai tổng điểm của toàn bộ thang đo.

Quy trình khảo sát chi tiết từ thiết kế bảng câu hỏi, tổ chức thực nghiệm, tính toán độ tin cậy đến phân tích định tính được mô tả ở Sơ đồ Hình 5.22.

> **Hình 5.22:** *Quy trình khảo sát và phân tích dữ liệu thực nghiệm.*

### 5.3.2 Phân tích kết quả khảo sát chi tiết

Khảo sát thực hiện trên 48 người:
* **Đối tượng:** Sinh viên Đại học chiếm 87.2%, trong đó lớn nhất là sinh viên năm hai (40.4%).
* **Mức độ làm quen với VR:** 45.8% chưa từng sử dụng kính VR, 54.2% đã từng trải nghiệm. Thời gian làm quen trung bình đối với người mới là 5 - 10 phút, người đã quen mất trung bình 20.88 phút (trung vị 10 phút) để thích nghi với môi trường mới. Sinh viên thường xuyên chơi game có tốc độ thích nghi nhanh hơn đáng kể.
* **Kinh nghiệm thực hành:** 58.3% học viên chưa từng học lắp dây mạng trước đây. Kỳ vọng lớn nhất của học viên là khả năng áp dụng kiến thức vào thực tế, bài học trực quan và có tính tương tác cao.

#### Đánh giá bài giảng truyền thống 2D (Qua Video và PDF)
Học viên tự học quy trình lắp đặt cáp Ethernet qua tài liệu 2D truyền thống trong 10 phút. Kết quả khảo sát định lượng được chi tiết tại **Bảng 5.1**:

| STT | Câu hỏi khảo sát | Điểm trung bình | Độ lệch chuẩn |
| :---: | :--- | :---: | :---: |
| **1** | Tôi đã đọc tài liệu hướng dẫn và xem video bài giảng nhiều lần. | 3.94 | 0.81 |
| **2** | Tôi ghi chép lại các bước thực hiện trong quá trình học. | 3.70 | 1.05 |
| **3** | Tôi hiểu rõ các bước thực hiện trong quy trình lắp đặt cáp Ethernet. | 3.77 | 1.07 |
| **4** | Tôi đã tìm hiểu thêm thông tin về lắp đặt cáp Ethernet từ các nguồn khác nhau. | 3.71 | 1.11 |
| **5** | Tôi cảm thấy có quyền tự do lựa chọn cách học và tốc độ học phù hợp với bản thân. | 3.96 | 1.09 |
| **6** | Tôi tin rằng việc học qua tài liệu 2D sẽ giúp tôi chuẩn bị tốt cho việc thực hành trên thiết bị thật. | 3.63 | 1.08 |
| **7** | Tôi không gặp khó khăn trong việc hiểu và ghi nhớ các bước thực hiện trong bài giảng 2D. | 3.48 | 1.11 |
| **8** | Bài giảng 2D cung cấp đủ thông tin để tôi có thể tự thực hành lắp đặt trên thiết bị thật. | 3.74 | 1.01 |

> **Bảng 5.1:** *Tự đánh giá của người học sau khi học bài giảng 2D về lắp đặt cáp Ethernet.*

#### Đánh giá bài giảng thực tế ảo 3D - Network Lab
Học viên thực hành trực tiếp trên ứng dụng Network Lab trong môi trường VR. Kết quả khảo sát định lượng được trình bày tại **Bảng 5.2**:

| STT | Câu hỏi khảo sát | Điểm trung bình | Độ lệch chuẩn |
| :---: | :--- | :---: | :---: |
| **1** | Tôi đã thực hành lắp đặt cáp Ethernet nhiều lần trong môi trường VR. | 3.98 | 0.91 |
| **2** | Tôi hiểu rõ các bước thực hiện trong quy trình lắp đặt cáp Ethernet. | 4.25 | 0.81 |
| **3** | Tôi có thể xác định và sửa chữa các lỗi thường gặp trong quá trình lắp đặt cáp Ethernet. | 4.10 | 0.75 |
| **4** | Tôi có thể áp dụng kiến thức đã học để giải quyết các tình huống lắp đặt cáp Ethernet khác nhau. | 4.23 | 0.63 |
| **5** | Tôi đã tìm kiếm thêm thông tin về lắp đặt cáp Ethernet từ các nguồn khác nhau. | 4.08 | 0.85 |
| **6** | Tôi cảm thấy bài thực hành VR là một trải nghiệm học tập thực tế và hữu ích. | 4.45 | 0.72 |
| **7** | Tôi cảm thấy tự tin hơn khi thực hành lắp đặt cáp Ethernet trên thiết bị thật sau khi trải nghiệm VR. | 4.38 | 0.67 |
| **8** | Tôi cảm thấy có quyền tự do lựa chọn cách học và thực hành trong môi trường VR. | 4.31 | 0.75 |
| **9** | Tôi cảm thấy bài thực hành VR giúp tôi nâng cao năng lực lắp đặt cáp Ethernet. | 4.33 | 0.72 |
| **10** | Tôi tin rằng việc thực hành trong VR sẽ giúp tôi tự tin hơn khi làm việc với các thiết bị mạng thật. | 4.33 | 0.81 |
| **11** | Các yếu tố như điểm số, huy hiệu, bảng xếp hạng giúp tôi có thêm động lực để thực hành trong VR. | 4.15 | 0.85 |
| **12** | Tôi cảm thấy tự tin hơn khi thực hiện các thao tác lắp đặt cáp Ethernet sau khi xem hướng dẫn và ví dụ trong VR. | 4.42 | 0.61 |
| **13** | Tôi cảm thấy lượng thông tin trong bài thực hành VR vừa đủ, không quá nhiều hoặc quá ít. | 4.35 | 0.64 |
| **14** | Tôi cảm thấy các thiết bị và công cụ trong VR giống với những gì tôi sử dụng trong thực tế. | 4.08 | 0.87 |
| **15** | Tôi cảm thấy tự tin hơn trong việc áp dụng kiến thức vào các tình huống thực tế sau khi thực hành trong VR. | 4.19 | 0.84 |
| **16** | Tôi cảm thấy VR tạo điều kiện cho việc tự học và khám phá kiến thức một cách linh hoạt. | 4.35 | 0.73 |
| **17** | Tôi cảm thấy các tương tác trong VR mô phỏng chân thực các thao tác kỹ thuật trong lắp đặt và cấu hình mạng. | 4.29 | 0.74 |
| **18** | Tôi cảm thấy môi trường VR cung cấp phản hồi kịp thời và chính xác, giúp tôi hiểu được các sai sót và cách khắc phục. | 4.31 | 0.66 |
| **19** | Tôi cảm thấy việc sử dụng VR trong học tập tạo ra một trải nghiệm học tập thú vị và tương tác cao. | 4.44 | 0.68 |
| **20** | Tôi thấy việc học lắp đặt cáp Ethernet trong VR hiệu quả hơn so với việc chỉ học lý thuyết và thực hành trên thiết bị thật. | 4.35 | 0.73 |
| **21** | Tôi thích học lắp đặt cáp Ethernet trong VR hơn so với việc học lý thuyết và thực hành trên thiết bị thật. | 4.40 | 0.64 |
| **22** | Bài thực hành VR có độ khó phù hợp với trình độ của tôi. | 4.15 | 0.71 |

> **Bảng 5.2:** *Tự đánh giá của người học sau khi học bài giảng 3D - Network Lab.*

* **So sánh thời gian hoàn thành lắp đặt thật:** 
  * Học viên học theo phương pháp truyền thống 2D mất trung bình **24.3 phút** (trung vị 20 phút) để hoàn thành lắp dây mạng thật, nhiều học viên không hoàn thành được.
  * Học viên học qua Network Lab trong môi trường VR giảm đáng kể thời gian hoàn thành xuống trung bình chỉ còn **15.28 phút** (trung vị 11 phút). 100% học viên đều hoàn thành bài thực hành thật một cách xuất sắc.

#### Đánh giá hiệu quả giáo dục bài giảng thực tế ảo Neo Terra
Thực hiện khảo sát trên 43 học viên trải nghiệm Neo Terra nhằm đánh giá hiệu quả nhận thức về môi trường và phân loại rác thải. Kết quả định lượng chi tiết tại **Bảng 5.3**:

| STT | Câu hỏi khảo sát | Điểm trung bình | Độ lệch chuẩn |
| :---: | :--- | :---: | :---: |
| **1** | Tôi đã thực hành phân loại rác nhiều lần trong môi trường VR. | 4.09 | 0.78 |
| **2** | Tôi nhận được phản hồi ngay lập tức về việc phân loại rác đúng hay sai. | 4.37 | 0.63 |
| **3** | Việc thực hành lặp đi lặp lại trong VR giúp tôi phân loại rác tốt hơn. | 4.37 | 0.65 |
| **4** | Tôi hiểu rõ các loại rác và cách phân loại chúng sau bài giảng. | 4.37 | 0.62 |
| **5** | Tôi có thể giải thích tại sao việc phân loại rác lại quan trọng. | 4.35 | 0.69 |
| **6** | Tôi có thể phân biệt được sự phân loại các loại rác thải. | 4.40 | 0.66 |
| **7** | Tôi đã chủ động tìm hiểu thêm thông tin về tái chế và phát triển bền vững sau bài giảng. | 4.21 | 0.77 |
| **8** | Tôi có thể áp dụng kiến thức đã học để đề xuất các giải pháp giảm thiểu rác thải trong cuộc sống hàng ngày. | 4.16 | 0.65 |
| **9** | Tôi đã tìm kiếm thêm thông tin về tái chế và phát triển bền vững từ các nguồn khác nhau. | 4.23 | 0.72 |
| **10** | Tôi sẽ chia sẻ và thảo luận với người khác về vấn đề tái chế và phát triển bền vững. | 4.23 | 0.78 |
| **11** | Bài giảng Neo Terra giúp tôi hiểu rõ hơn về tác động của rác thải đến môi trường. | 4.35 | 0.65 |
| **12** | Tôi cảm thấy có trách nhiệm hơn trong việc bảo vệ môi trường sau bài giảng. | 4.40 | 0.59 |
| **13** | Tôi cảm thấy bài giảng Neo Terra khơi dậy sự quan tâm của tôi đến vấn đề môi trường. | 4.30 | 0.65 |
| **14** | Tôi cảm thấy có động lực để tìm hiểu thêm về phát triển bền vững. | 4.28 | 0.71 |
| **15** | Tôi cảm thấy bài giảng Neo Terra cho tôi quyền tự do khám phá và tìm hiểu theo cách riêng của mình. | 4.19 | 0.62 |
| **16** | Tôi tin rằng việc phân loại rác đúng cách sẽ giúp cải thiện môi trường sống. | 4.42 | 0.59 |

> **Bảng 5.3:** *Đánh giá hiệu quả giáo dục của bài giảng thực tế ảo Neo Terra về phân loại rác và bảo vệ môi trường.*

#### Tính nhất quán khoa học của kết quả khảo sát
Phân tích hệ số Cronbach's alpha khẳng định độ tin cậy cực kỳ cao của dữ liệu khảo sát:
* Thang đo Likert trong khảo sát Network Lab đạt $\alpha = \mathbf{0.96}$.
* Thang đo Likert trong khảo sát Neo Terra đạt $\alpha = \mathbf{0.94}$.

Hệ số $\alpha > 0.9$ củng cố vững chắc tính nhất quán nội bộ và giá trị khoa học của kết quả thực nghiệm trong đồ án tốt nghiệp.

---

## 5.4 Thảo luận kết quả

Thực nghiệm đã khẳng định công nghệ thực tế ảo có tác động to lớn trong việc nâng cao kỹ năng thực hành kỹ thuật chuyên môn và phát triển nhận thức của người học:
* **Ưu điểm:** Học viên đánh giá cao môi trường tương tác trực quan 3D, sự hướng dẫn sinh động của robot, tính phản hồi tức thì, và sự an toàn khi thử sai.
* **Hạn chế hiện tại:** Thiếu phản hồi lực xúc giác thật khi thao tác kìm bấm mạng ảo; yêu cầu về chi phí thiết bị phần cứng kính VR tương đối cao so với điều kiện tiếp cận rộng rãi của học sinh, sinh viên Việt Nam hiện nay.
* **Đề xuất cải tiến:** Tích hợp tay cầm phản hồi xúc giác rung nâng cao; tiếp tục tối ưu hóa đồ họa để chạy mượt mà trên các phân khúc kính VR giá rẻ; đa dạng hóa thêm nhiều bài giảng thực hành chuyên môn khác.

## 5.5 Kết luận chương 5

Kết quả khảo sát qua hệ thống **The VR Labs** đã khẳng định tính đột phá của việc ứng dụng công nghệ thực tế ảo vào giảng dạy thực hành kỹ thuật. **Network Lab** mang lại sự tự tin và rút ngắn đáng kể thời gian thao tác bấm cáp Ethernet trên thiết bị thật. **Neo Terra** giúp củng cố sâu sắc trách nhiệm bảo vệ môi trường của người học thông qua câu chuyện nhập vai đầy tính nhân văn và các tương tác trò chơi hóa hấp dẫn.

---

# Chương 6: Kết Luận

## 6.1 Tổng kết đồ án tốt nghiệp

Đồ án tốt nghiệp đã giải quyết thành công vấn đề thiếu hụt trải nghiệm thực hành và động lực tự học trong các chương trình giáo dục trực tuyến từ xa bằng cách đề xuất, phát triển và đánh giá thực nghiệm hệ thống bài giảng thực tế ảo **The VR Labs**. 

Hệ thống đã triển khai hoàn thiện hai bài học cốt lõi:
1. **Network Lab:** Giảng dạy trực quan quy trình lắp đặt cáp Ethernet chuẩn xác.
2. **Neo Terra:** Trò chơi hóa nội dung 17 mục tiêu phát triển bền vững của Liên Hợp Quốc, tích hợp chatbot robot thông minh sử dụng mô hình AI tạo sinh.

Khảo sát thực nghiệm khoa học trên **48 học viên** cho thấy mức độ cải thiện rõ rệt về kỹ năng thực tế, mức độ tiếp thu bài học vượt trội và độ tin cậy khảo sát cực kỳ cao ($\alpha > 0.94$). Đây là tiền đề khoa học vững chắc khẳng định tính khả thi của việc ứng dụng công nghệ thực tế ảo phục vụ giáo dục kỹ thuật tại Việt Nam.

## 6.2 Hướng phát triển trong tương lai

Trong tương lai dài hạn, hệ thống **The VR Labs** định hướng phát triển trở thành một nền tảng giáo dục thực tế ảo toàn diện, hỗ trợ người thiết kế bài học tự tạo nội dung và cho phép học viên học tập đa tương tác, kết nối cơ sở dữ liệu đồng bộ với hệ thống **MOOC** trường học (`daotao.ai`).

> **Hình 6.1:** *Đề xuất phát triển hệ thống giáo dục thực tế ảo trong tương lai dài hạn.*

Kiến trúc hệ thống tương lai đề xuất (Hình 6.1) bao gồm:
* **Server-side:** Quản lý cơ sở dữ liệu học tập, các yêu cầu từ phía người dùng thông qua web server, cơ sở dữ liệu khóa học và lưu trữ đám mây của hệ thống MOOC.
* **Môi trường thực tế ảo (VR Client):** Tương tác đa chiều giữa học viên, giảng viên và robot ảo trong thế giới 3D, tích hợp các bộ giả lập thực hành và cung cấp công cụ tự tạo kịch bản giảng dạy cho giảng viên.
* **Tích hợp trí tuệ nhân tạo (AI):** Tự động cá nhân hóa lộ trình học tập, điều chỉnh tốc độ hướng dẫn và phản hồi lực/xúc giác ảo phù hợp cho từng cá nhân người học.

---

## Tài Liệu Tham Khảo

[1] Statista Research Department. "Size of the global e-learning market in 2019 and 2026, by segment (in billion U.S. dollars)." Infographic, Global e-learning market size by segment 2019 with a forecast for 2026, Jul. 6, 2022. [Online]. Available: https://www.statista.com/statistics/1130331/e-learning-market-size-segment-worldwide/.
[2] M. D. B. Castro and G. M. Tumibay. "A literature review: Efficacy of online learning courses for higher education institution using meta-analysis." *Education and Information Technologies*, vol. 26, pp. 1367–1385, 2019. DOI: 10.1007/s10639-019-10027-z.
[3] L. Tsarova, I. Kovalova, and N. Martynenko. "Self-study work in online mode as an innovative foreign language learning technology." *Scientific Bulletin of Flight Academy. Section: Pedagogical Sciences*, 2022. DOI: 10.33251/2522-1477-2022-12-158-164.
[4] M. F. Sedon, C. Z. Zulkifli, M. Khairani, A. B. Sabran, and A. A. Zalay. "Covid-19: Disadvantages of online learning towards visual arts practiced-based nature." *IJEBD (International Journal of Entrepreneurship and Business Development)*, 2021. DOI: 10.29138/ijebd.v4i1.1123.
[5] Statista. "Online learning problems faced by children during the covid-19 pandemic in vietnam as of april 2020." [Online]. Available: https://www.statista.com/statistics/1190894/vietnam-online-learning-problems-for-children-during-covid-19-pandemic/.
[6] A. V. Lê, T. T. H. Đặng, T. D. Bùi, Q. A. Vương, T. T. Phùng, và Đ. L. Đỗ. "Thực trạng học tập trực tuyến của học sinh phổ thông việt nam trong bối cảnh COVID-19." *Tạp chí Khoa học Giáo dục Việt Nam*, vol. 18, no. 03, pp. 1–10, 2022. DOI: 10.15625/2615-8957/12210301.
[7] T. H. Nguyễn, T. T. Nguyễn, và T. T. Nguyễn. "Ứng dụng công nghệ thực tế ảo trong hoạt động dạy học." *Tạp chí Khoa học và Công nghệ*, vol. 65, no. 7, pp. 6573–6578, 2023.
[8] VR360. "Tổng hợp thông tin báo cáo vr trong giáo dục mới nhất." *VR360 Giải pháp Thực tế ảo VR, AR, 3D, 360, Map3D*, pp. 1–17.
[9] EdTech Agency. "Vietnam’s EdTech White Paper." Copyrighted material Conducted by EdTech Agency, Aug. 2023.
[10] "Các xu thế ứng dụng công nghệ 'ảo' trong giáo dục." *Tạp chí Giáo dục Việt Nam*, 2023. [Online]. Available: https://tapchigiaoduc.edu.vn/article/87160/225/cac-xu-the-ung-dung-cong-nghe-ao-trong-giao-duc/.
[11] K.-C. Hu, D. Salcedo, Y.-N. Kang, and et al. "Impact of virtual reality anatomy training on ultrasound competency development: A randomized controlled trial." *PLoS ONE*, vol. 15, 2020. DOI: 10.1371/journal.pone.0242731.
[12] E.-A. Kim and K.-J. Cho. "Comparing the effectiveness of two new cpr training methods in korea: Medical virtual reality simulation and flipped learning." *Iranian Journal of Public Health*, vol. 52, pp. 1428–1438, 2023. DOI: 10.18502/ijph.v52i7.13244.
[13] G. M. Enda McGovern and C. Luna-Nevarez. "An application of virtual reality in education: Can this technology enhance the quality of students’ learning experience?" *Journal of Education for Business*, vol. 95, no. 7, pp. 490–496, 2020. DOI: 10.1080/08832323.2019.1703096.
[14] S. Nikolic, D. Stirling, and M. Ros. "Formative assessment to develop oral communication competency using youtube: Self- and peer assessment in engineering." *European Journal of Engineering Education*, vol. 43, pp. 1–14, Mar. 2017. DOI: 10.1080/03043797.2017.1298569.
[15] T. M. Uoc. "Digital transformation in higher education in vietnam today." *Revista de Gestão e Secretariado (Management and Administrative Professional Review)*, 2023. DOI: 10.7769/gesec.v14i8.2699.
[16] United Nations. "Objectifs de développement durable." [Online]. Available: https://www.un.org/sustainabledevelopment/fr/objectifs-de-developpement-durable/.
[17] Organisation internationale de la Francophonie. "Hackathon « jeu parle français » : Dix équipes lựa chọn cho la finale à bucarest!" [Online]. Available: https://parlonsfrancais.francophonie.org/hackathon-jeu-parle-francais-dix-equipes-selectionnees-pour-la-finale-a-bucarest/.
[18] N. V. Hạnh. *Lý luận và phương pháp dạy học, Giáo dục trải nghiệm – Một nền tảng giáo dục trong thế kỉ 21*. Hà Nội: Trường Đại học Bách Khoa Hà Nội, Viện Sư phạm Kỹ thuật, 2020.
[19] R. Phillips. "Challenging the primacy of lectures: the dissonance between theory and practice in university teaching." *Journal of University Teaching & Learning Practice*, vol. 2, Jan. 2005. DOI: 10.53761/1.2.1.2.
[20] World Economic Forum. "Schools of the future: Defining new models of education for the fourth industrial revolution," 2020. [Online]. Available: https://www.weforum.org/publications/schools-of-the-future-defining-new-models-of-education-for-the-fourth-industrial-revolution/.
[21] G. P. Papanastasiou, A. Drigas, C. Skianis, M. D. Lytras, and E. Papanastasiou. "Virtual and augmented reality effects on k-12, higher and tertiary education students’ twenty-first century skills." *Virtual Reality*, vol. 23, pp. 425–436, 2018. DOI: 10.1007/s10055-018-0363-2.
[22] N. Pellas, A. Dengel, and A. Christopoulos. "A scoping review of immersive virtual reality in stem education." *IEEE Transactions on Learning Technologies*, vol. 13, pp. 748–761, 2020. DOI: 10.1109/TLT.2020.3019405.
[23] U. A. Chattha, U. Janjua, F. Anwar, T. M. Madni, M. F. Cheema, and S. I. Janjua. "Motion sickness in virtual reality: An empirical evaluation." *IEEE Access*, vol. 8, pp. 130486–130499, 2020. DOI: 10.1109/ACCESS.2020.3007076.
[24] P. Caserman, A. Garcia-Agundez, A. G. Zerban, and S. Göbel. "Cybersickness in current-generation virtual reality head-mounted displays: Systematic review and outlook." *Virtual Reality*, vol. 25, pp. 1153–1170, 2021. DOI: 10.1007/s10055-021-00513-6.
[25] T. Alsop. "Volume of vr headsets worldwide 2018-2028." Statista, 2024. [Online]. Available: https://www.statista.com/forecasts/1331896/vr-headset-sales-volume-worldwide/.
[26] R. C. Richey. "Reflections on the 2008 aect definitions of the field." *TechTrends*, vol. 52, no. 1, pp. 24–25, 2008. DOI: 10.1007/s11528-008-0108-2.
[27] M. Weller. "25 years of ed tech." Athabasca University Press, 2020. DOI: 10.15215/aupress/9781771993050.01.
[28] L. Jarmon, T. Traphagan, M. Mayrath, and A. Trivedi. *Virtual world teaching, experiential learning, and assessment: An interdisciplinary communication course in Second Life*. Elsevier, 2009, vol. 53, pp. 169–182.
[29] M. Ulum and A. Fauzi. "Behaviorism theory and its implications for learning." *Journal of Insan Mulia Education*, 2023. DOI: 10.59923/joinme.v1i2.41.
[30] Y. Lu and Y. A. Hamu. "Teori operant conditioning menurut burrhus frederic skinner." *Jurnal Arrabona*, vol. 5, no. 1, 2022. DOI: 10.57058/juar.v5i1.65.
[31] W. Mursyidi. "Kajian teori belajar behaviorisme dan thiết kế dạy học." 2020. DOI: 10.38153/almarhalah.v3i1.30.
[32] G. Akhundova. "The transition from cognitivism to constructivism in foreign language teaching: Comparative analysis." vol. 1, pp. 177–181, 2020. DOI: 10.24919/2308-4863/34-1-28.
[33] J. Mattar. "Constructivism and connectivism in education technology: Active, situated, authentic, experiential, and anchored learning." *RIED: Revista Iberoamericana de Educación a Distancia*, vol. 21, pp. 201–217, 2018. DOI: 10.5944/RIED.21.2.20055.
[34] J. R. Utecht and D. M. Keller. "Becoming relevant again: Applying connectivism learning theory to today’s classrooms." *Critical Questions in Education*, vol. 10, pp. 107–119, 2019.
[35] A. Y. Kolb and D. Kolb. "Experiential learning theory as a guide for experiential educators in higher education." *Experiential Learning and Teaching in Higher Education*, 2022. DOI: 10.46787/elthe.v1i1.3362.
[36] H. P. Young. "Learning by trial and error." *Games and Economic Behavior*, vol. 65, no. 2, pp. 626–643, 2009. DOI: 10.1016/j.geb.2008.02.011.
[37] N. R. Salikhova, M. F. Lynch, and A. Salikhova. "Psychological aspects of digital learning: A self-determination theory perspective." *Contemporary Educational Technology*, 2020. DOI: 10.30935/cedtech/8584.
[38] D. D. Gallo. "Expectancy theory as a predictor of individual response to computer technology." *Computers in Human Behavior*, vol. 2, pp. 31–41, 1986. DOI: 10.1016/0747-5632(86)90020-8.
[39] P. Buckley and E. Doyle. "Gamification and student motivation." *Interactive Learning Environments*, vol. 24, pp. 1162–1175, 2016. DOI: 10.1080/10494820.2014.964263.
[40] M. Sailer and L. Homner. "The gamification of learning: A meta-analysis." *Educational Psychology Review*, vol. 32, pp. 77–112, 2019. DOI: 10.1007/s10648-019-09498-w.
[41] J. R. Hill, L. Song, and R. West. "Social learning theory and web-based learning environments: A review of research and discussion of implications." *American Journal of Distance Education*, vol. 23, pp. 103–88, 2009. DOI: 10.1080/08923640902857713.
[42] R. Duran, A. Zavgorodniaia, and J. Sorva. "Cognitive load theory in computing education research: A review." *ACM Transactions on Computing Education (TOCE)*, vol. 22, pp. 1–27, 2022. DOI: 10.1145/3483843.
[43] K. Inna, T. Liudmyla, V. Iryna, and M. Nataliia. "Implementing the theory of multiple intelligences into project-based multimedia learning at primary school." *Information Technologies and Learning Tools*, vol. 82, pp. 18–31, 2021. DOI: 10.33407/ITLT.V82I2.4326.
[44] M. Kapur. "Productive failure in learning math." *Cognitive Science*, vol. 38, no. 6, pp. 1008–1022, 2014.
[45] A. Cisneros, M. Maravilla, B. Murray, D. Scretching, A. Stoddard, and E. M. Redmiles. "Defining virtual reality: Insights from research and practice." in *iConference 2019 Proceedings*, 2019. DOI: 10.21900/iconf.2019.103338.
[46] D. Freeman, S. Reeve, A. Robinson, and et al. "Virtual reality in the assessment, understanding, and treatment of mental health disorders." *Psychological Medicine*, vol. 47, no. 14, pp. 2393–2400, 2017. DOI: 10.1017/S003329171700040X.
[47] C. Cruz-Neira, D. J. Sandin, and T. A. DeFanti. "Surround-screen projection-based virtual reality: The design and implementation of the CAVE." in *ACM Computer Graphics (SIGGRAPH) Proceedings*, vol. 27, 1993, pp. 135–142.
[48] M. Slater, B. Spanlang, M. Sanchez-Vives, and O. Blanke. "First person experience of body transfer in virtual reality." *PLoS ONE*, vol. 5, no. 4, e10564, 2010. DOI: 10.1371/journal.pone.0010564.
[49] B. Spanlang, J.-M. Normand, D. Borland, and et al. "How to build an embodiment lab: Achieving body representation illusions in virtual reality." *Frontiers in Robotics and AI*, vol. 1, 2014. DOI: 10.3389/frobt.2014.00009.
[50] M. Ferrer-Garcia, J. Gutierrez-Maldonado, J. Treasure, and F. Vilalta-Abella. "Craving for food in virtual reality scenarios in a non-clinical sample: Analysis of its relationship with body mass index and eating disorder symptoms." *European Eating Disorders Review*, vol. 23, no. 5, pp. 371–378, 2015. DOI: 10.1002/erv.2374.
[51] W. Luo. "The benefit of a regression in vr game." in *Highlights in Science, Engineering and Technology CMLAI 2023*, vol. 39, 2023, pp. 376–382.
[52] R. P. McMahan, D. A. Bowman, D. J. Zielinski, and R. B. Brady. "Evaluating display fidelity and interaction fidelity in a virtual reality game." in *2012 IEEE Virtual Reality (VR)*, IEEE, 2012, pp. 15–22.
[53] Y. Liu. "Analysis of interaction methods in vr virtual reality." *Highlights in Science, Engineering and Technology*, 2023. DOI: 10.54097/hset.v39i.6559.
[54] K. Mills and A. Brown. "Immersive virtual reality (vr) for digital media making: Transmediation is key." *Learning, Media and Technology*, vol. 47, pp. 179–200, 2021. DOI: 10.1080/17439884.2021.1952428.
[55] D. A. Bowman and R. P. McMahan. "Virtual reality: How much immersion is enough?" *Computer*, vol. 40, no. 7, pp. 36–43, Jul. 2007. DOI: 10.1109/MC.2007.263.
[56] R. J. Teather, W. Stuerzlinger, and J. Shephard. "The effect of frame rate on simulator sickness for a first-person perspective task." *Displays*, vol. 44, pp. 1–8, Aug. 2016. DOI: 10.1016/j.displa.2016.05.001.
[57] M. Slater, A. Antley, A. Davison, and et al. "A virtual reprise of the stanley milgram obedience experiments." *PLoS ONE*, vol. 1, no. 1, e39, Aug. 2006. DOI: 10.1371/journal.pone.0003939.
[58] Pico. "Pico 4 - thiết bị thực tế ảo." https://www.picoxr.com/, [Truy cập ngày 28/06/2024], 2024.
[59] Meta. "Meta quest 2 - virtual reality headset." https://www.meta.com/quest/products/quest-2/, [Truy cập ngày 28/06/2024], 2024.
[60] BKVerse Team. "Kho lưu trữ module của bkverse team: bkverse-module." https://github.com/bkverse-team/bkverse-module, 2023.
[61] EdTech Centre - daotao.ai. "Hướng nghiệp 4.0 ngành công nghệ thông tin." https://www.facebook.com/edtechcentredaotaoai/videos/1934648476898080, [Truy cập ngày 29 tháng 6, 2024], 2023.

---

# Phụ Lục

## Phụ Lục A: Lịch Sử Phát Triển Của Công Nghệ Giáo Dục

Bảng A.1 trình bày các mốc thời gian quan trọng trong sự phát triển của công nghệ giáo dục từ năm 1994 đến năm 2018, dựa trên nghiên cứu của Weller (2020) [27].

| Năm | Sự kiện chính | Mô tả ngắn gọn |
| :---: | :--- | :--- |
| **1994** | Hệ thống bảng tin (BBS) | Tiền thân của các nền tảng mạng xã hội và diễn đàn trực tuyến ngày nay, cho phép người dùng kết nối, chia sẻ nội dung và trao đổi thông tin. |
| **1995** | Web | Sự ra đời của web tạo ra cuộc cách mạng trong giáo dục, cung cấp nền tảng rộng lớn để xuất bản, giao tiếp và chia sẻ thông tin, tạo điều kiện cho việc học tập từ xa. |
| **1996** | Giao tiếp qua máy tính (CMC) | CMC bao gồm email, diễn đàn thảo luận, nhắn tin tức thời, tạo ra cơ hội học tập và hợp tác trực tuyến mới mẻ. |
| **1997** | Chủ nghĩa kiến tạo | Lý thuyết học tập nhấn mạnh vai trò chủ động của người học trong việc xây dựng kiến thức thông qua trải nghiệm thực tế và tương tác xã hội. |
| **1998** | Wiki | Các trang web cho phép người dùng cùng nhau chỉnh sửa nội dung, thúc đẩy tinh thần hợp tác và chia sẻ tri thức cộng đồng (ví dụ: Wikipedia). |
| **1999** | Học trực tuyến (E-learning) | Trở thành một phần tất yếu của giáo dục hiện đại, kết hợp web, CMC, chủ nghĩa kiến tạo và các công cụ wiki để cung cấp các chương trình học tập linh hoạt. |
| **2000** | Đối tượng học tập (LO) | Áp dụng tính linh hoạt và khả năng tái sử dụng của lập trình hướng đối tượng vào giáo dục, đặt nền móng cho tài nguyên giáo dục mở (OER). |
| **2001** | Tiêu chuẩn học trực tuyến | Sự ra đời của IMS và SCORM giúp giải quyết vấn đề tương thích nội dung giữa các nền tảng; giới thiệu Dublin Core mô tả tài nguyên kỹ thuật số. |
| **2002** | Hệ thống quản lý học tập (LMS) | LMS/VLE cung cấp giải pháp tập trung quản lý khóa học, diễn đàn thảo luận và học liệu trực tuyến hiệu quả. |
| **2003** | Blog | Công cụ phổ biến cho phép chia sẻ ý tưởng học thuật cá nhân, tạo phản xạ tư duy và hình thành cộng đồng học tập đa ngành. |
| **2004** | Tài nguyên giáo dục mở (OER) | Phong trào cung cấp học liệu mở miễn phí, điển hình là sáng kiến OpenCourseWare của trường đại học MIT danh tiếng. |
| **2005** | Video (YouTube) | Cuộc cách mạng hóa giáo dục qua video trực tuyến, dân chủ hóa việc sản xuất và chia sẻ nội dung học tập sáng tạo. |
| **2006** | Web 2.0 | Chuyển dịch sang dịch vụ tương tác cao và nội dung do người dùng tự tạo; folksonomies, đánh dấu trang xã hội và mã nhúng giúp học tập cộng tác dễ dàng hơn. |
| **2007** | Thế giới ảo (Second Life) | Thử nghiệm các bài giảng ảo và môi trường học tập 3D nhập vai, tuy nhiên gặp rào cản lớn về hạ tầng công nghệ và tính thực tế thời bấy giờ. |
| **2008** | E-portfolios | Hồ sơ năng lực kỹ thuật số cho phép người học lưu trữ sản phẩm học tập, tự đánh giá, phản ánh tiến trình phát triển và chia sẻ thành tựu. |
| **2009** | Twitter & MXH | Cách mạng hóa giao tiếp học thuật, cho phép thảo luận toàn cầu theo thời gian thực và xây dựng mạng lưới học tập cá nhân linh hoạt. |
| **2010** | Chủ nghĩa kết nối | Lý thuyết học tập kỷ nguyên số xem kiến thức nằm phân tán trong một mạng lưới các nút thông tin và học tập là quá trình tạo kết nối giữa chúng. |
| **2011** | Môi trường học tập cá nhân (PLE) | Tập hợp các công cụ tự định hướng học tập cá nhân, trao toàn quyền kiểm soát và cá nhân hóa cho người học. |
| **2012** | Khóa học trực tuyến mở quy mô lớn (MOOC) | Mở rộng cơ hội tiếp cận giáo dục đại học miễn phí cho hàng triệu người học trên thế giới (Coursera, edX). |
| **2013** | Sách giáo khoa mở (Open Textbooks) | Phiên bản học liệu kỹ thuật số miễn phí chất lượng cao (ví dụ: OpenStax), giúp tiết kiệm tối đa chi phí cho sinh viên. |
| **2014** | Phân tích học tập (Learning Analytics) | Khai thác dữ liệu học tập để tối ưu hóa hiệu quả giảng dạy, phát hiện sớm các khó khăn của học viên và can thiệp kịp thời. |
| **2015** | Huy hiệu kỹ thuật số (Digital Badges) | Hình thức công nhận năng lực và kỹ năng cụ thể linh hoạt, có thể xác minh trực tuyến và chia sẻ dễ dàng với nhà tuyển dụng. |
| **2016** | Sự trở lại của trí tuệ nhân tạo (AI) | AI đột phá trong cá nhân hóa học tập thích ứng, ITS (hệ thống dạy kèm thông minh) và đánh giá tự động. |
| **2017** | Blockchain | Ứng dụng để lưu trữ và xác minh văn bằng học thuật an toàn, bảo mật và trao quyền sở hữu dữ liệu học tập cho người học. |
| **2018** | Phê phán công nghệ giáo dục (EdTech) | Chuyển hướng tiếp cận phê phán về các vấn đề đạo đức, quyền riêng tư dữ liệu học sinh, sự giám sát mạng và bất bình đẳng kỹ thuật số. |

> **Bảng A.1:** *Các cột mốc quan trọng trong quá trình phát triển của công nghệ trong giáo dục.*

---

## Phụ Lục B: Phiếu Khảo Sát Ứng Dụng The VR Labs

### Phần 1: Thông tin cá nhân

* **1.1 Họ và tên:** ..........................................................................
* **1.2 Tuổi:** ..........................................................................
* **1.3 Email:** ..........................................................................
* **1.4 Trình độ chuyên môn:**
  * [ ] Sinh viên năm nhất Đại học
  * [ ] Sinh viên năm hai Đại học
  * [ ] Sinh viên năm ba Đại học
  * [ ] Sinh viên năm tư Đại học
  * [ ] Sinh viên năm năm Đại học
  * [ ] Học sinh THPT
  * [ ] Khác: ...................................
* **1.5 Tên trường:** ..........................................................................
* **1.6 MSSV (nếu có):** ..........................................................................

### Phần 2: Thông tin chung về bài giảng và sử dụng thiết bị VR

* **Câu hỏi 2.1:** Bạn tham gia những bài giảng nào?
  * [ ] Network Lab
  * [ ] Neo Terra
* **Câu hỏi 2.2:** Bạn đã sử dụng thiết bị VR trước đó chưa?
  * [ ] Rồi
  * [ ] Chưa
* **Câu hỏi 2.3:** Bạn mất bao lâu để làm quen với thiết bị VR? ...................................

### Phần 3: Khảo sát bài học thực hành Network Lab

* **Câu hỏi 3.1:** Bạn đã từng học lắp dây mạng trước đây chưa?
  * [ ] Rồi
  * [ ] Chưa
* **Câu hỏi 3.2:** Bạn kỳ vọng gì ở bài giảng lắp dây mạng? ....................................................................................................................................................................................................

#### Học thực hành lắp dây mạng qua Video và tài liệu 2D (Thời gian: 10 phút)
* **Câu hỏi 3.3.1:** Bạn đánh giá thế nào về bài giảng 2D?
  *(Thang đo: 1 - Hoàn toàn không đồng ý, 2 - Không đồng ý, 3 - Không ý kiến, 4 - Đồng ý, 5 - Hoàn toàn đồng ý)*

| STT | Nhận xét về bài giảng 2D | Mức độ đồng ý (1-5) |
| :---: | :--- | :---: |
| **1** | Tôi đã đọc tài liệu hướng dẫn và xem video bài giảng nhiều lần. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **2** | Tôi ghi chép lại các bước thực hiện trong quá trình học. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **3** | Tôi hiểu rõ các bước thực hiện trong quy trình lắp đặt cáp Ethernet. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **4** | Tôi đã tìm hiểu thêm thông tin về lắp đặt cáp từ các nguồn khác nhau. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **5** | Tôi cảm thấy có quyền tự do lựa chọn cách học và tốc độ học phù hợp với bản thân. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **6** | Tôi tin rằng việc học qua nguồn tài liệu 2D sẽ giúp tôi chuẩn bị tốt cho việc lắp đặt trên thiết bị thật. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **7** | Tôi không gặp khó khăn trong việc hiểu và ghi nhớ các bước thực hiện trong bài giảng 2D. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **8** | Bài giảng 2D cung cấp đủ thông tin để tôi có thể tự thực hành lắp đặt trên thiết bị thật. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |

> **Bảng B.1:** *Bảng nhận xét về bài giảng 2D.*

* **Câu hỏi 3.3.2:** Thời gian hoàn thành bấm cáp trên thiết bị thật sau khi học 2D: ........................ phút.
* **Câu hỏi 3.3.3:** Các yếu tố nào khiến bạn cảm thấy hào hứng và muốn tiếp tục học? ....................................................................................................................................................................................................

#### Học qua VR với ứng dụng Network Lab
* **Câu hỏi 3.4.1:** Bạn đánh giá thế nào về bài giảng Network Lab trong môi trường VR?
  *(Thang đo: 1 - Hoàn toàn không đồng ý, 2 - Không đồng ý, 3 - Không ý kiến, 4 - Đồng ý, 5 - Hoàn toàn đồng ý)*

| STT | Nhận xét về bài thực hành VR - Network Lab | Mức độ đồng ý (1-5) |
| :---: | :--- | :---: |
| **1** | Tôi đã thực hành lắp đặt cáp Ethernet nhiều lần trong môi trường VR. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **2** | Tôi hiểu rõ các bước thực hiện trong quy trình lắp đặt cáp Ethernet. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **3** | Tôi có thể xác định và sửa chữa các lỗi thường gặp trong quá trình lắp đặt. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **4** | Tôi có thể áp dụng kiến thức để giải quyết các tình huống lắp đặt khác nhau. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **5** | Tôi đã tìm kiếm thêm thông tin về lắp đặt cáp Ethernet từ nguồn khác. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **6** | Tôi cảm thấy bài thực hành VR là một trải nghiệm học tập thực tế và hữu ích. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **7** | Tôi cảm thấy tự tin hơn khi thực hành trên thiết bị thật sau khi trải nghiệm VR. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **8** | Tôi cảm thấy có quyền tự do lựa chọn cách học và thực hành trong môi trường VR. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **9** | Tôi cảm thấy bài thực hành VR giúp tôi nâng cao năng lực lắp đặt cáp Ethernet. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **10** | Tôi tin rằng việc thực hành trong VR giúp tôi tự tin hơn khi làm việc với thiết bị mạng thật. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **11** | Các yếu tố trò chơi hóa (điểm số, bảng xếp hạng) giúp tôi có thêm động lực học. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **12** | Tôi tự tin hơn khi thực hiện các thao tác sau khi xem hướng dẫn và ví dụ trong VR. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **13** | Lượng thông tin trong bài thực hành VR vừa đủ, không quá tải. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **14** | Các thiết bị và công cụ mô phỏng trong VR giống với những gì sử dụng trong thực tế. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **15** | Tôi cảm thấy tự tin áp dụng kiến thức vào thực tế sau khi thực hành trong VR. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **16** | Tôi cảm thấy VR tạo điều kiện cho việc tự học và khám phá linh hoạt. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **17** | Các tương tác trong VR mô phỏng chân thực các thao tác kỹ thuật thực tế. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **18** | Môi trường VR cung cấp phản hồi kịp thời, chính xác giúp tôi nhận ra lỗi sai. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **19** | Học tập qua VR tạo ra một trải nghiệm học tập vô cùng thú vị và tương tác cao. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **20** | Học lắp đặt cáp trong VR hiệu quả hơn so với chỉ học lý thuyết và thực hành thiết bị thật. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **21** | Tôi thích học lắp đặt cáp Ethernet trong VR hơn so với phương pháp truyền thống. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **22** | Bài thực hành VR có độ khó phù hợp với trình độ của tôi. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |

> **Bảng B.2:** *Bảng nhận xét về bài giảng Network Lab.*

* **Câu hỏi 3.4.2:** Thời gian hoàn thành bấm cáp trên thiết bị thật sau khi học VR: ........................ phút.

### Phần 4: Khảo sát bài học thực tế ảo Neo Terra

* **Câu hỏi 4.1:** Bạn hãy tự đánh giá về bài giảng thực tế ảo Neo Terra sau khi trải nghiệm:
  *(Thang đo: 1 - Hoàn toàn không đồng ý, 2 - Không đồng ý, 3 - Không ý kiến, 4 - Đồng ý, 5 - Hoàn toàn đồng ý)*

| STT | Nhận xét về bài giảng Neo Terra | Mức độ đồng ý (1-5) |
| :---: | :--- | :---: |
| **1** | Tôi đã thực hành phân loại rác nhiều lần trong môi trường VR. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **2** | Tôi nhận được phản hồi ngay lập tức về việc phân loại rác đúng hay sai. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **3** | Việc thực hành lặp đi lặp lại trong VR giúp tôi phân loại rác tốt hơn. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **4** | Tôi hiểu rõ các loại rác và cách phân loại chúng sau bài giảng. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **5** | Tôi có thể giải thích tại sao việc phân loại rác lại quan trọng. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **6** | Tôi có thể phân biệt được sự phân loại các loại rác thải. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **7** | Tôi đã chủ động tìm hiểu thêm thông tin về tái chế và phát triển bền vững sau bài giảng. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **8** | Tôi có thể áp dụng kiến thức để đề xuất các giải pháp giảm thiểu rác thải trong đời sống. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **9** | Tôi đã tìm kiếm thêm thông tin về tái chế và phát triển bền vững từ các nguồn khác nhau. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **10** | Tôi sẽ chia sẻ và thảo luận với người khác về vấn đề tái chế và phát triển bền vững. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **11** | Bài giảng Neo Terra giúp tôi hiểu rõ hơn về tác động của rác thải đến môi trường. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **12** | Tôi cảm thấy có trách nhiệm hơn trong việc bảo vệ môi trường sau bài giảng. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **13** | Tôi cảm thấy bài giảng Neo Terra khơi dậy sự quan tâm của tôi đến vấn đề môi trường. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **14** | Tôi cảm thấy có động lực để tìm hiểu thêm về phát triển bền vững. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **15** | Tôi cảm thấy bài giảng Neo Terra cho tôi quyền tự do khám phá và tìm hiểu theo cách riêng. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |
| **16** | Tôi tin rằng việc phân loại rác đúng cách sẽ giúp cải thiện môi trường sống. | [ ] 1 [ ] 2 [ ] 3 [ ] 4 [ ] 5 |

> **Bảng B.3:** *Bảng nhận xét về bài giảng Neo Terra.*

* **Câu hỏi 4.2:** Liệt kê 3 từ vựng tiếng Pháp với nghĩa tiếng Việt bạn học được qua bài giảng Neo Terra:
  1. ..........................................................................
  2. ..........................................................................
  3. ..........................................................................
* **Câu hỏi 4.3:** Liệt kê 3 cách tái chế bạn học được qua bài giảng Neo Terra:
  1. ..........................................................................
  2. ..........................................................................
  3. ..........................................................................

### Phần 5: Đánh giá chung

* **Câu hỏi 5.1:** Bạn thấy học bằng phương pháp nào thú vị hơn?
  * [ ] Học bằng các tài liệu 2D truyền thống
  * [ ] Học qua ứng dụng thực tế ảo VR
* **Câu hỏi 5.2:** Bạn đề xuất cải thiện ứng dụng thế nào để phát triển thêm The VR Labs?
  ..................................................................................................................................................................................................................................................................................................
* **Câu hỏi 5.3:** Bạn thấy điểm nào ở ứng dụng VR chưa bằng học truyền thống?
  ..................................................................................................................................................................................................................................................................................................
* **Câu hỏi 5.4:** Bạn thấy điểm nào ở ứng dụng VR vượt trội hơn học truyền thống?
  ..................................................................................................................................................................................................................................................................................................
* **Câu hỏi 5.5:** Bạn đã thử nghiệm bài giảng nào, bao nhiêu lần, trong bao lâu để hiểu và ứng dụng được?
  ..................................................................................................................................................................................................................................................................................................

***Cảm ơn bạn đã hoàn thành khảo sát!***
