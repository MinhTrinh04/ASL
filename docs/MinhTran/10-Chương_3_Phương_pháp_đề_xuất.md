CHƯƠNG 3. PHƯƠNG PHÁP ĐỀ XUẤT
3.1.1 Tổng quan ứng dụng The VR Labs
The VR Labs là một ứng dụng thực tế ảo được phát triển trên nền tảng Unity, sử
dụng công nghệ OpenXR để đảm bảo khả năng tương thích với nhiều loại kính VR
khác nhau. Ứng dụng này được thiết kế nhằm cung cấp môi trường học tập thực
hành tương tác và phong phú, hỗ trợ người học tiếp cận kiến thức và rèn luyện kỹ
năng một cách hiệu quả.
Giao diện người dùng của The VR Labs được thiết kế theo hướng trực quan và
dễ sử dụng, cho phép người học dễ dàng điều hướng giữa các bài giảng, lựa chọn
bài giảng thực hành. Ứng dụng tích hợp các tính năng như đánh giá, phản hồi tức
thì và hướng dẫn chi tiết, tạo điều kiện cho người học tự đánh giá và cải thiện kỹ
năng.
Trong phạm vi của đồ án này, The VR Labs tập trung vào hai mục tiêu chính là

```
(i) thực hành kỹ năng, cung cấp môi trường thực hành ảo cho các kỹ năng cụ thể
```

trong lĩnh vực công nghệ thông tin, ví dụ như bài giảng Network Lab về lắp đặt dây

```
mạng Ethernet; và (ii) trò chơi hóa lý thuyết, tích hợp các yếu tố trò chơi hóa vào
```

các bài giảng lý thuyết để tăng cường sự hấp dẫn và động lực học tập, như trong
bài giảng Neo Terra về phát triển bền vững.

```
Logo của The VR Labs (Hình 3.1) là sự kết hợp giữa hình ảnh chiếc mũ tốt
```

```
nghiệp (biểu tượng của giáo dục) và kính thực tế ảo, thể hiện rõ định hướng ứng
```

dụng công nghệ VR vào lĩnh vực giáo dục. Tên gọi "The VR Labs" cũng nhấn
mạnh ý nghĩa này, tượng trưng cho "Các phòng thí nghiệm thực tế ảo", một không
gian học tập sáng tạo và hiện đại, nơi người học có thể trải nghiệm và thực hành
trong môi trường mô phỏng chân thực.
Hình 3.1: Logo của ứng dụng The VR Labs, biểu tượng của sự đổi mới trong giáo dục
công nghệ thông tin qua thực tế ảo.
Trong Hình 3.2, giao diện màn hình khởi đầu của ứng dụng The VR Labs được
trình bày, nơi người dùng có thể chọn bài giảng thực hành. Giao diện này bao gồm

```
ba lựa chọn chính: (i) Network Lab; (ii) Neo Terra; và (iii) Coming Soon, chỉ ra
```

sự mở rộng tương lai với các bài giảng mới. Giao diện này không chỉ là điểm xuất
phát cho hành trình học tập mà còn phản ánh sự đa dạng và tiềm năng của The VR
Labs trong việc cung cấp trải nghiệm giáo dục thực tế ảo.
27
CHƯƠNG 3. PHƯƠNG PHÁP ĐỀ XUẤT
Hình 3.2: Giao diện màn khởi đầu lựa chọn bài giảng của The VR Labs.
3.1.2 Công nghệ sử dụng
Ứng dụng The VR Labs được phát triển và triển khai dựa trên những công nghệ
và thiết bị phần cứng phổ biến, dễ tiếp cận, có tiềm năng giảm bớt công sức cho
các nhà phát triển khác khi xây dựng các bài giảng tương tự.
Về phần mềm, các phần mềm và công cụ chính được sử dụng bao gồm: Unity,
OpenXR, C#, Blender, Mixamo, Meshy AI, Gemini 1.5 Pro và Google Text-to-
Speech. Trong đó, Unity được lựa chọn làm nền tảng phát triển chính cho ứng
dụng The VR Labs, không chỉ nhờ vào khả năng tạo ra môi trường VR tương tác
và hấp dẫn mà còn nhờ vào hệ sinh thái rộng lớn bao gồm các tài nguyên sẵn có
và cộng đồng lập trình viên đông đảo. Unity được sử dụng để thiết kế giao diện
người dùng, xây dựng môi trường VR, xử lý tương tác và tích hợp các tính năng
đa phương tiện, hỗ trợ đa dạng các ngôn ngữ lập trình, bao gồm C#. Điểm mạnh
của Unity nằm ở khả năng tạo ra các trải nghiệm đồ họa 3D và 2D chất lượng cao,
cũng như hỗ trợ mạnh mẽ cho việc phát triển trò chơi và ứng dụng tương tác. Thư
viện tài nguyên phong phú của Unity, bao gồm mô hình, kịch bản, và các hiệu ứng
âm thanh, giúp quá trình phát triển trở nên nhanh chóng và hiệu quả.
Để đảm bảo ứng dụng có thể chạy trên nhiều nền tảng phần cứng khác nhau

```
(bao gồm Pico và Oculus Quest), OpenXR, một API đa nền tảng mạnh mẽ, được
```

tích hợp vào The VR Labs. Điều này giúp đơn giản hóa quá trình phát triển và triển
khai, cho phép ứng dụng tiếp cận được nhiều người dùng hơn với các thiết bị VR
khác nhau. OpenXR không chỉ cung cấp một bộ công cụ thống nhất để tương tác
với các thiết bị VR mà còn hỗ trợ các tính năng tiên tiến như theo dõi tay, theo
28
CHƯƠNG 3. PHƯƠNG PHÁP ĐỀ XUẤT
dõi mắt và phản hồi xúc giác, mở ra nhiều khả năng mới cho việc tạo ra các trải
nghiệm VR phong phú và hấp dẫn, tuy nhiên các tính năng này vẫn chưa được phát
triển ổn định cho quá trình sử dụng, nên tôi vẫn dùng tay cầm để tương tác với môi
trường VR.
Trong quá trình triển khai lập trình, không thể thiếu được việc triển khai các
chức năng logic, do đó, ngôn ngữ C# được lựa chọn làm ngôn ngữ lập trình chính
để phát triển các thành phần logic và tương tác của ứng dụng. C# là ngôn ngữ mặc
định của Unity khi viết các logic xử lý sự kiện, tương tác với các đối tượng trong
môi trường 3D, và xử lý dữ liệu C# được chọn vì tính dễ học, dễ sử dụng, cú pháp
rõ ràng và hỗ trợ mạnh mẽ từ cộng đồng lập trình viên, giúp tăng tốc quá trình phát
triển và giảm thiểu lỗi phát sinh.
Khi triển khai một ứng dụng VR, việc cần các mô hình 3D là điều cần thiết.
Blender, một phần mềm mô hình hóa 3D miễn phí và mã nguồn mở, được sử dụng
để tạo ra các mô hình 3D chi tiết và chân thực, làm phong phú thêm môi trường
VR. Sau khi được tạo ra, các mô hình này được xuất sang định dạng tương thích
với Unity, giúp tích hợp mượt mà vào ứng dụng. Vì nhà phát triển thường không
chuyên thiết kế nên việc sử dụng Meshy AI, một công cụ hỗ trợ tạo mô hình 3D
mạnh mẽ, giúp đơn giản hóa quá trình tạo nội dung 3D cho môi trường VR. Công

```
cụ này tận dụng trí tuệ nhân tạo để chuyển đổi hình ảnh 2D (hoặc văn bản) thành
```

mô hình 3D chi tiết và chân thực, giảm thiểu đáng kể thời gian và công sức cần
thiết để tạo ra các nội dung 3D phức tạp.
Sau khi đã có mô hình, để cho các nhân vật trở nên sinh động, việc thêm khung
xương và chuyển động cho các nhân vật 3D là điều cần thiết. Vì thế, quá trình phát
triển The VR Labs có sử dụng Mixamo, một dịch vụ trực tuyến, cung cấp thư viện
đa dạng các chuyển động 3D có thể tùy chỉnh. Dịch vụ này giúp tiết kiệm đáng kể
thời gian và công sức trong việc tạo ra các chuyển động phức tạp cho nhân vật và
đối tượng trong môi trường VR.
Để sinh dữ liệu trò chuyện cho robot, tích hợp Gemini Pro 1.5, một mô hình

```
ngôn ngữ lớn (LLM), cung cấp khả năng xử lý ngôn ngữ tự nhiên (NLP) cho robot
```

hỗ trợ trong bài giảng Neo Terra. Gemini Pro 1.5 có khả năng hiểu và phản hồi các
câu hỏi của người dùng một cách thông minh và tự nhiên, tạo ra trải nghiệm tương
tác chân thực và thú vị. Mô hình này được huấn luyện trên một lượng lớn dữ liệu
văn bản và có thể thực hiện các tác vụ NLP như phân tích ngữ nghĩa, tạo văn bản và
dịch ngôn ngữ. Nhờ vào Gemini Pro 1.5, robot có thể trả lời các câu hỏi của người
dùng về các vật thể trong môi trường ảo, cung cấp thông tin về cách tái chế các vật
liệu khác nhau và thậm chí là trò chuyện với người dùng bằng tiếng Pháp. Hơn thế
29
CHƯƠNG 3. PHƯƠNG PHÁP ĐỀ XUẤT
nữa, sau khi có dữ liệu, robot cần nói chuyện để phản hồi lại cho người dùng. Vì

```
thế, Google Text-to-Speech (TTS), một công cụ chuyển đổi văn bản thành giọng
```

nói, đã được sử dụng để tạo ra giọng nói cho robot. Google TTS hỗ trợ nhiều ngôn
ngữ và giọng nói khác nhau, cho phép chúng tôi tùy chỉnh giọng nói của robot sao
cho phù hợp với tính cách và ngữ cảnh của bài giảng. Việc sử dụng Google TTS
mang lại cho robot một giọng nói tự nhiên và biểu cảm, giúp tăng cường tính tương
tác và hấp dẫn của trải nghiệm học tập trong môi trường VR.
Về phần cứng, Pico 4 và Oculus Quest 2 là hai thiết bị thực tế ảo độc lập được

```
lựa chọn để trải nghiệm ứng dụng The VR Labs. Pico 4 (xem tại hình 3.3) được
```

trang bị chip Qualcomm Snapdragon XR2, RAM 8 GB và bộ nhớ trong lên đến
256 GB, mang đến hiệu năng mạnh mẽ để xử lý đồ họa và ứng dụng VR. Thiết bị
này sở hữu màn hình LCD độ phân giải 4K+ với mật độ điểm ảnh cao, tái hiện hình
ảnh sắc nét và sống động. Bên cạnh đó, hệ thống âm thanh không gian 3D tích hợp
giúp người dùng đắm chìm sâu hơn vào môi trường ảo.

```
Hình 3.3: Kính thực tế ảo Pico 4. Nguồn: Pico (2024). [58]
```

```
Oculus Quest 2 (xem tại hình 3.4) cũng được trang bị chip Qualcomm Snap-
```

dragon XR2, RAM 6 GB, đảm bảo hiệu suất tốt cho các ứng dụng VR. Màn hình
LCD gần 2K của Oculus Quest 2 tuy có độ phân giải thấp hơn Pico 4 nhưng vẫn
cung cấp hình ảnh rõ nét và chi tiết. Điểm nổi bật của Oculus Quest 2 là khả năng
hỗ trợ tốc độ làm mới lên đến 120 Hz, mang lại trải nghiệm mượt mà và giảm thiểu
hiện tượng giật hình khi người dùng di chuyển trong môi trường ảo.

```
Cả Pico 4 và Oculus Quest 2 đều hỗ trợ chế độ theo dõi 6DoF (6 bậc tự do), cho
```

phép người dùng di chuyển và xoay tự do trong không gian ba chiều. Ngoài ra, chế
độ theo dõi tay trên cả hai thiết bị giúp người dùng tương tác một cách tự nhiên
và trực quan với môi trường ảo, không cần sử dụng bộ điều khiển. Nhờ những tính
năng này, Pico 4 và Oculus Quest 2 là những lựa chọn phù hợp để mang đến trải
nghiệm học tập VR chất lượng cao với The VR Labs.
30
CHƯƠNG 3. PHƯƠNG PHÁP ĐỀ XUẤT

```
Hình 3.4: Kính thực tế ảo Meta Quest 2. Nguồn: Meta (2024). [59]
```

3.2 Thiết kế nội dung bài giảng thực hành Network Lab
Phần trên là tổng quan hệ thống The VR Labs với hai bài giảng thực hành được
thiết kế trong phạm vi của đồ án. Một trong những bài giảng đó là bài giảng thực
hành lắp dây mạng - Network Lab. Bài giảng này được phát triển dựa trên nội dung
của học phần Mạng máy tính tại Trường Công nghệ Thông tin và Truyền thông,
Đại học Bách khoa Hà Nội. Bài giảng này được thiết kế để mô phỏng chân thực
quy trình lắp đặt cáp mạng Ethernet trong môi trường thực tế ảo, nhằm cung cấp
cho người học trải nghiệm thực hành tương tác và trực quan, đồng thời giúp họ nắm
vững kiến thức và kỹ năng cần thiết.
Hình 3.5 minh họa ý tưởng chính của bài giảng Network Lab trong môi trường
VR. Hình ảnh này cũng được sử dụng làm giao diện lựa chọn bài giảng trong ứng
dụng The VR Labs, với logo đặc trưng của trải nghiệm Network Lab.
Hình 3.5: Hình ảnh sử dụng để lựa chọn bài giảng Network Lab với logo của trải nghiệm
Network Lab
Quy trình thiết kế bài giảng được cấu trúc thành năm giai đoạn chính. Đầu tiên,
31
CHƯƠNG 3. PHƯƠNG PHÁP ĐỀ XUẤT
xác định mục tiêu bài giảng, trong đó các kiến thức và kỹ năng cụ thể mà người

```
học cần đạt được sau khi hoàn thành bài giảng được xác định rõ ràng (xem tại mục
```

```
3.2.1). Tiếp theo, thiết kế nội dung bài giảng, quá trình này bao gồm việc xây dựng
```

nội dung chi tiết cho bài giảng, với cả phần lý thuyết và thực hành, đảm bảo tính

```
chính xác, khoa học và phù hợp với môi trường thực tế ảo (xem tại mục 3.2.2). Giai
```

đoạn thứ ba là giải thích và phân tích lý thuyết, trình bày cơ sở lý luận và các lý

```
do dẫn đến việc lựa chọn phương pháp thiết kế bài giảng cụ thể (xem tại Chương
```

```
4). Giai đoạn thứ tư là triển khai phát triển phần mềm, trong đó bài giảng được xây
```

```
dựng trên môi trường thực tế ảo (xem tại Chương 5). Cuối cùng là giai đoạn thực
```

hiện khảo sát đánh giá, thu thập phản hồi từ người học và đánh giá hiệu quả của

```
bài giảng nhằm mục đích cải tiến và nâng cao chất lượng (xem tại Chương 5)
```

3.2.1 Xác định mục tiêu bài giảng
Trong bài giảng này, mục tiêu chính là trang bị cho sinh viên những kiến thức
và kỹ năng cơ bản về lắp đặt cáp mạng Ethernet. Cụ thể, sinh viên sẽ được hướng
dẫn để hiểu rõ về các loại cáp mạng và tiêu chuẩn đấu nối đầu cáp với cáp xoắn
đôi. Điều này bao gồm việc phân biệt giữa cáp thẳng và cáp chéo, cũng như hiểu
rõ ứng dụng của chúng trong thực tế. Bên cạnh đó, một phần quan trọng của bài
giảng là việc trau dồi kỹ năng bấm đầu cáp mạng theo tiêu chuẩn, một kỹ năng
thiết yếu cho bất kỳ ai làm việc trong lĩnh vực mạng máy tính. Bài giảng này được
thiết kế để phù hợp với sinh viên năm nhất hoặc năm hai đang theo học các ngành
như Công nghệ Thông tin, Điện tử Viễn thông, hoặc các ngành có liên quan, nhằm
cung cấp một nền tảng vững chắc cho sự nghiệp tương lai của họ trong lĩnh vực
này.
3.2.2 Thiết kế nội dung bài giảng
Trong phần thực hành của bài giảng, người học sẽ được hướng dẫn qua từng
bước cụ thể để thực hiện việc lắp đặt cáp mạng như hướng dẫn trong bảng 3.1. Mỗi
bước được thực hiện trong môi trường thực tế sẽ tương ứng với các hoạt động được
mô phỏng trong môi trường thực tế ảo, nhằm tạo điều kiện cho người học có thể
hình dung và thực hành một cách dễ dàng trong một không gian ảo mô phỏng gần
với thực tế. Tuy nhiên, cần lưu ý rằng một số thao tác có thể không thể mô phỏng
một cách hoàn hảo 100% so với thực tế, song vẫn bảo đảm được độ chính xác và
tương tác cao. Trong quá trình thiết kế, tôi sẽ áp dụng các phương pháp mô tả thích
hợp để đảm bảo trải nghiệm người dùng được tối ưu.
Trong giai đoạn đầu của quy trình thực hành, cụ thể là tại bước 1, người học
được yêu cầu thực hiện việc cắt một đoạn cáp mạng với chiều dài xác định là 0.5
mét. Điều này đòi hỏi người học phải sử dụng kìm để cắt cáp mạng, dụng cụ này
32
CHƯƠNG 3. PHƯƠNG PHÁP ĐỀ XUẤT
thường được thiết kế với chức năng: cắt đứt cáp mạng và tuốt lớp vỏ bảo vệ của cáp.
Mỗi chức năng sẽ ở tại vị trí khác nhau trên kìm bấm mạng. Trong môi trường thực
tế ảo, người học cũng cần phải lựa chọn chính xác vị trí cắt trên kìm ảo để thực
hiện việc cắt cáp mạng một cách chính xác. Tiếp theo, tại bước 2 của quy trình,
người học sẽ tiến hành tuốt lớp vỏ bảo vệ của cáp mạng, để có thể thấy được các
dây đồng bên trong dây mạng. Trong môi trường VR, người dùng cũng cần phải
tìm đúng vị trí để có thể tuốt được lớp vỏ bên ngoài dây mạng.
Tại bước 3 của quy trình, người học được yêu cầu thực hiện việc gỡ xoắn và ghép
cặp các dây theo màu sắc tương ứng. Tuy nhiên, trong môi trường thực tế ảo, việc
mô phỏng các thao tác chi tiết nhỏ như gỡ xoắn và ghép cặp dây màu giống nhau
gặp phải hạn chế về mặt kỹ thuật. Cụ thể, do giới hạn về khoảng cách tối thiểu mà
hai tay cầm VR có thể tiếp cận gần nhau, việc mô phỏng chính xác các thao tác này
trở nên không khả thi tính đến thời điểm hiện tại khi thực hiện triển khai ứng dụng
VR sử dụng tay cầm làm thao tác. Do đó, để tối ưu hóa quy trình học và thực hành
trong VR, tôi quyết định thay thế bằng một thao tác trong VR đó chính là bấm nút
để có thể gỡ xoắn dây mạng.
Tiếp theo, bước 4 đòi hỏi việc sử dụng ngón tay để duỗi thẳng và sắp xếp các
cặp dây theo thứ tự màu sắc đúng đắn, phù hợp với loại dây mạng đang được lắp
đặt. Bước này được gọi là "Sắp xếp dây mạng". Trong bước này, người học sẽ sử
dụng bộ điều khiển VR để di chuyển và sắp xếp các dây mạng một cách hợp lý.
Đồng thời, một màn hình hướng dẫn sẽ hiển thị cách sắp xếp đúng các dây mạng,
giúp người học có thể dễ dàng làm theo và ghi nhớ.
Trong bước 5, người học được khuyến khích thực hiện một thao tác cắt chính xác
tại vị trí đã được xác định trước, sử dụng kìm bấm để tạo ra một đường cắt thẳng
qua tám sợi dây, nhằm đảm bảo chiều dài của phần dây đồng còn lại là khoảng 1,3
cm, tính từ điểm cuối của ống bọc đã được cắt đến đầu dây. Tuy nhiên, qua quá
trình đánh giá và phân tích trong môi trường thực tế ảo, bước này không được xem
là hoàn toàn cần thiết để triển khai. Mục tiêu chính của bài giảng này là trang bị
cho người học kiến thức và kỹ năng về các bước cắt dây mạng cơ bản, do đó, việc
tinh chỉnh lại một số phần dây thừa có thể khiến người học mất thêm thời gian mà
không tập trung vào các bước chính của quy trình. Hơn nữa, việc cắt dây mạng với
chiều dài chính xác đã được thực hiện trong quá trình tuốt vỏ dây mạng. Vì lý do
này, tôi quyết định loại bỏ bước này khỏi quy trình thực hành trong môi trường thực
tế ảo. Thay vào đó, tại bước này tôi cho người dùng thử sai và xác định với nút bấm
xem là mình đã xếp đúng thứ tự dây mạng hay chưa.
Tại bước 6, tương tự như trong môi trường thực tế, người học cần phải đưa toàn
33
CHƯƠNG 3. PHƯƠNG PHÁP ĐỀ XUẤT
bộ tám sợi dây đã được tuốt vỏ vào đầu nối mạng. Trong môi trường thực tế ảo,
người học cũng được yêu cầu cầm hạt mạng và đưa dây mạng vào vị trí chính xác.
Trong thực tế, việc này đòi hỏi phải áp dụng lực bấm mạnh để đảm bảo phần dây
mạng được đưa vào sâu và đúng vị trí trong hạt mạng. Do đó, trong môi trường
VR, người học cũng cần phải thực hiện thao tác tương tự, nhằm tạo ra cảm giác ấn
mạnh như khi thực hiện trong thực tế.
Tiếp theo, bước thứ 7 yêu cầu người học đưa dây mạng đã được nối với hạt mạng
vào vị trí chính xác trên kìm bấm để thực hiện việc bấm dây mạng.
Cuối cùng, khi thực hiện thành công bảy bước trên, một thông báo chúc mừng
sẽ được hiển thị, thông báo cho người học về việc hoàn thành quy trình. Tại thời
điểm này, người học có thể lựa chọn chơi lại hoặc thoát và chọn một bài giảng khác
để tiếp tục.
STT Mô tả thực tế
Hình ảnh thực
tế
Mô tả bước tương
ứng trong VR
Hình ảnh
trong VR
1
Sử dụng dụng cụ
bấm mạng để cắt
một đoạn cáp mạng
với chiều dài là 0.5
mét.
Để cắt hẳn dây
mạng, cần đặt cáp
vào vị trí cắt chính
xác trên kìm và bấm
cắt bằng tay cầm
VR.
2
Sử dụng kìm bấm
mạng để tuốt lớp vỏ
ngoài của cáp
khoảng 2.5cm tính
từ một đầu cáp.
Tuốt lớp vỏ ngoài
của cáp mô phỏng
với chiều dài tương
tự. Cần đặt vào
đúng vị trí tuốt vỏ
dây mạng và bấm
nút trên tay cầm VR
3
Gỡ xoắn và ghép
các cặp dây có màu
giống nhau.
Chạm vào nút bấm
màu xanh trên bàn
để gỡ xoắn dây
mạng
34
CHƯƠNG 3. PHƯƠNG PHÁP ĐỀ XUẤT
STT Mô tả thực tế
Hình ảnh thực
tế
Mô tả bước tương
ứng trong VR
Hình ảnh
trong VR
4
Dùng ngón tay giữ
và duỗi thẳng các
cặp dây, sắp xếp các
dây theo màu sắc
đúng thứ tự theo
loại dây mạng cần
lắp đặt.
Sử dụng bộ điều
khiển VR để gỡ
xoắn, ghép cặp và
sắp xếp các dây theo
màu sắc. Màn hình
hướng dẫn sẽ hiển
thị cách sắp xếp
đúng.
5
Cắt dây mạng bằng
kìm để tạo ra một
đoạn dây đồng
thẳng, dài khoảng
1,3 cm tính từ điểm
cuối của ống bọc
nhựa.
Kiểm tra và xác
nhận thứ tự dây
mạng bằng cách đưa
vào nút màu xanh,
có thể lặp lại để đảm
bảo độ chính xác.
6
Đưa toàn bộ 8 sợi
dây đã tuốt vỏ vào
đầu nối, đảm bảo
ống bọc nhựa màu
xanh nằm hoàn toàn
bên trong và dây
dẫn chạm đến tận
cùng của đầu nối.
Cầm dây mạng và
hạt mạng để nối
chúng vào với nhau.
7
Bấm đầu cáp vào
hạt mạng bằng kìm:
đặt đầu hạt mạng đã
được nối dây vào
kìm, ấn mạnh để cố
định dây. Lưỡi kìm
xuyên dây, cố định
ống bọc, tạo kết nối
chắc chắn. Lúc này,
đầu dây mạng đã có
thể sử dụng được.
Cho đầu hạt mạng
đã được nối dây
mạng vào đúng vị
trí ở kìm và thực
hiện bấm bằng tay
cầm VR
35
CHƯƠNG 3. PHƯƠNG PHÁP ĐỀ XUẤT
STT Mô tả thực tế
Hình ảnh thực
tế
Mô tả bước tương
ứng trong VR
Hình ảnh
trong VR
8
Lặp bước 2-7 cho
đầu cáp thứ hai. Đối
cáp chéo, thứ tự
màu sắc đầu còn lại
khác với thứ tự vừa
thực hiện.
Có thể dùng các nút
trong thế giới ảo để
thực hiện lại các
thao tác.
Bảng 3.1: Các bước trong thực hành lắp dây mạng
Bảng 3.1 đã trình bày các bước cần thiết để lắp đặt cáp mạng Ethernet, cũng như
mô phỏng các bước tương ứng trong môi trường thực tế ảo. Mỗi bước được thiết
kế để giúp người học hiểu rõ hơn về quy trình lắp đặt cáp mạng và cung cấp cơ hội
thực hành một cách chân thực nhất. Đồng thời, việc mô phỏng các bước này trong
môi trường thực tế ảo cũng giúp giảm bớt khó khăn và rủi ro khi thực hiện trong
môi trường thực tế, đồng thời tạo ra một môi trường học tập an toàn và hiệu quả
cho người học. Chi tiết phân tích lý thuyết tại sao lại có thiết kế các bước bài giảng
như vậy sẽ được trình bày cụ thể tại chương 4.
3.3 Thiết kế nội dung bài giảng thực hành Neo Terra
Phần trên đã mô tả thiết kế kế nội dung bài giảng Network Lab. Trong ứng dụng
The VR Labs, một phần bài giảng không kém phần quan trọng đó chính là bài
giảng Neo Terra. Neo Terra là một bài giảng thực tế ảo được thiết kế nhằm nâng
cao nhận thức về phát triển bền vững, đặc biệt tập trung vào vấn đề phân loại và
tái chế rác thải. Bài giảng sử dụng yếu tố trò chơi hóa để tạo ra trải nghiệm học tập
hấp dẫn và tương tác, khuyến khích người học tham gia tích cực và ghi nhớ kiến
thức một cách dễ dàng.

```
Logo của Neo Terra (Hình 3.6) được thiết kế dựa trên ý tưởng về một hành tinh
```

xanh cần được bảo vệ. Hình ảnh quả địa cầu cách điệu với tông màu xanh lá cây
chủ đạo tượng trưng cho Trái Đất và thiên nhiên. Biểu tượng kính VR được lồng
ghép vào hình ảnh quả địa cầu, thể hiện việc ứng dụng công nghệ thực tế ảo vào

```
việc nâng cao nhận thức về môi trường. Chữ "Neo" (mới) và "Terra" (Trái Đất) kết
```

hợp với nhau tạo nên tên gọi "Neo Terra", mang ý nghĩa về một Trái Đất mới, một
tương lai bền vững mà chúng ta hướng tới.
Màu xanh lá cây được sử dụng xuyên suốt trong logo, tượng trưng cho thiên
nhiên, sự sống và sự phát triển bền vững. Logo có hai phiên bản, một phiên bản
36
CHƯƠNG 3. PHƯƠNG PHÁP ĐỀ XUẤT
nền xanh lá cây và một phiên bản nền trắng, để phù hợp với các ngữ cảnh sử dụng
khác nhau.
Hình 3.6: Hình ảnh mô tả bài giảng Neo Terra với logo của trò chơi Neo Terra
3.3.1 Xác định mục tiêu bài giảng
Bài giảng Neo Terra được thiết kế với mục tiêu chính là nâng cao nhận thức và
hành động của người học về vấn đề phân loại và tái chế rác thải, đồng thời đóng
góp vào các mục tiêu phát triển bền vững của Liên Hợp Quốc. Bài giảng không chỉ
cung cấp kiến thức cơ bản về các loại rác thải và quy trình tái chế mà còn tạo cơ
hội cho người học thực hành phân loại rác thải trong môi trường thực tế ảo tương
tác, giúp họ rèn luyện kỹ năng một cách trực quan và thú vị. Bên cạnh đó, bài giảng
còn truyền cảm hứng và khuyến khích người học tham gia tích cực vào các hoạt
động bảo vệ môi trường và phát triển bền vững, hướng đến một tương lai xanh và
sạch hơn.
Đặc biệt, Neo Terra tập trung vào việc đóng góp vào các mục tiêu phát triển bền
vững của Liên Hợp Quốc như giáo dục chất lượng, năng lượng sạch, cơ sở hạ tầng
bền vững, tiêu dùng và sản xuất có trách nhiệm, hành động vì khí hậu, bảo vệ hệ
sinh thái và hợp tác toàn cầu. Ngoài ra, bài giảng còn có các mục tiêu phụ như giúp
người học khám phá tiềm năng tái chế của các loại vật liệu khác nhau và học tiếng
Pháp thông qua các hoạt động tương tác trong môi trường VR.
3.3.2 Thiết kế nội dung bài giảng
Neo Terra mở đầu bằng việc đưa người học vào một thế giới tương lai giả tưởng,
nơi Trái Đất đang phải đối mặt với những hậu quả nặng nề do thiếu nhận thức
về phát triển bền vững. Thông qua cốt truyện hấp dẫn và những thước phim 360
độ chân thực, người học sẽ trực tiếp chứng kiến những tác động tiêu cực đến môi
37
CHƯƠNG 3. PHƯƠNG PHÁP ĐỀ XUẤT
trường, từ đó khơi dậy sự đồng cảm và ý thức trách nhiệm đối với việc bảo vệ hành
tinh.
Từ nhận thức về vấn đề, bài giảng chuyển sang phần thực hành thông qua trò
chơi phân loại rác thải. Đây không chỉ là một hoạt động giải trí mà còn là một
phương pháp giáo dục hiệu quả, giúp người học củng cố kiến thức về các loại rác
thải và cách phân loại chúng một cách chính xác. Tính điểm và yếu tố cạnh tranh
được lồng ghép vào trò chơi, tạo động lực để người học hoàn thành xuất sắc nhiệm
vụ và biến việc học trở thành một trải nghiệm thú vị.
Tiếp nối hành trình, người học sẽ được khám phá một thế giới ảo tương tác, nơi
họ có thể tìm hiểu về trí tuệ nhân tạo và ứng dụng của nó trong việc tái chế và xử lý
rác thải. Thông qua việc tương tác với robot thông minh, người học không chỉ mở
rộng kiến thức về công nghệ mà còn nhận thức được tiềm năng to lớn của nó trong
việc giải quyết các vấn đề môi trường cấp bách.
Cuối cùng, bài giảng Neo Terra còn tích hợp việc học tiếng Pháp thông qua
tương tác với robot. Người học có thể khám phá môi trường ảo, trỏ vào các vật thể
và tìm hiểu từ vựng tiếng Pháp tương ứng, cùng với nghĩa tiếng Việt và cách phát
âm. Đây là một phương pháp học ngoại ngữ sáng tạo, giúp người học tiếp thu kiến
thức một cách tự nhiên và thú vị trong quá trình trải nghiệm thế giới ảo.
Trong phần nội dung học tập, chúng ta sẽ tập trung vào hai nội dunchính. Đầu
tiên, học viên sẽ được hướng dẫn cách phân loại rác thải một cách chính xác vào
các thùng rác có màu sắc tương ứng, nhằm nâng cao ý thức về việc bảo vệ môi
trường thông qua việc phân loại rác thải đúng cách. Tiếp theo, người học sẽ trải
nghiệm việc tiếp nhận thông tin thông qua tương tác với robot tích hợp trí tuệ nhân
tạo.
Trong bài giảng Neo Terra, để tạo trải nghiệm tương tác tốt nhất, người học
được trang bị khả năng thực hiện một loạt các thao tác trong môi trường VR. Cụ
thể, người học có thể di chuyển tự do trong không gian ảo bằng cách sử dụng bộ
điều khiển hoặc đi bộ như trong thực thế, cầm nắm và di chuyển các vật thể như rác
thải và công cụ phân loại, ném rác thải vào đúng thùng để phân loại, và tương tác
với các nhân vật cũng như đối tượng khác trong môi trường VR thông qua bộ điều
khiển hoặc giọng nói. Điều này không chỉ làm cho việc học trở nên sinh động và
thú vị hơn mà còn giúp người học cảm thấy mình đang tham gia vào một thế giới
ảo chân thực, nơi họ có thể áp dụng kiến thức và kỹ năng của mình một cách trực
tiếp.
Trong bài giảng Neo Terra, câu chuyện xoay quanh nhân vật chính Kael, một
nhà khoa học trẻ tuổi và tài năng, cùng với robot đồng hành Aethos. Đặt bối cảnh
38
CHƯƠNG 3. PHƯƠNG PHÁP ĐỀ XUẤT
vào năm 2072, khi Trái Đất đang đối mặt với một thảm họa môi trường nghiêm
trọng, bầu khí quyển ô nhiễm nặng nề đến mức con người không thể sống ngoài
trời mà không có sự bảo vệ đặc biệt. Kael sống sót trong một khu vực biệt lập
nhờ vào công nghệ tiên tiến và có một người bạn đồng hành đặc biệt từ nhỏ, robot
Aethos, một sản phẩm công nghệ tiên tiến do cha mẹ anh để lại.
Một cơn bão cát dữ dội bất ngờ ập đến, phá hủy nhiều công trình và đe dọa tính
mạng của người dân trong khu vực. Trong lúc tìm kiếm nơi trú ẩn, Kael và Aethos
tình cờ lạc vào một hang động cổ xưa, nơi họ tìm thấy "Lõi Gaia" – một cổ vật
công nghệ bí ẩn của nền văn minh cổ đại, được bảo vệ bởi một hệ thống an ninh
tiên tiến. Với sự giúp đỡ của Aethos, Kael vượt qua các thử thách để chứng minh
mình xứng đáng nhận được sự giúp đỡ từ cổ vật này.
Lõi Gaia, mặc dù chưa thức tỉnh hoàn toàn, đã truyền một phần năng lượng vào
Aethos, giúp robot này tiến hóa lên một cấp bậc mới, mạnh mẽ và thông minh hơn.
Với sự hỗ trợ của Aethos, Kael quyết định sử dụng Lõi Gaia để làm sạch Trái Đất
và khám phá những bí mật đằng sau cổ vật này. Hành trình của Kael và Aethos bắt
đầu từ đây, với mục tiêu không chỉ làm sạch môi trường mà còn tìm cách đánh thức
hoàn toàn Lõi Gaia và khôi phục lại vẻ đẹp nguyên sơ của Trái Đất.
39
CHƯƠNG 3. PHƯƠNG PHÁP ĐỀ XUẤT
Kịch bản Thiết kế trong VR Hình ảnh trong VR
Cảnh mở đầu
Kael choàng tỉnh trong căn
phòng thí nghiệm tối tăm, ánh
sáng xanh lập loè từ những thiết
bị hư hỏng càng khiến không
gian xung quanh có phần phần
kỳ quái. Đầu cậu đau nhức, ký
ức mơ hồ.

```
Kael: (Lẩm bẩm) "Chuyện gì...
```

đã xảy ra...?"
Kael cố gắng gượng dậy, nhưng
mỗi cử động đều như ngàn cân
đè nặng. Xung quanh cậu là
khung cảnh hỗn loạn của những
mảnh vỡ máy móc, dây điện đứt
gãy và rác thải công nghiệp chất
đống ngổn ngang. Người bạn
đồng hành Aethos nằm bất động
gần đó, ánh đèn tín hiệu đã tắt.
Cảnh mở đầu là phòng
thí nghiệm một cơn bão
cát với rác thải và một
căn phòng trong tương
lai bị tàn phá. Người
học sau khi lựa chọn bài
giảng Neo Terra sẽ được
đưa vào cảnh này.
Tìm thấy giải pháp - Bắt đầu trò chơi
Kael lục lọi xung quanh, tay cậu
chạm vào một mảnh giấy cũ kỹ.
Dòng chữ nguệch ngoạc hiện
lên: "Hồi sinh từ đống tro tàn,
tìm thấy ánh sáng trong bóng
tối."
Một cái bàn với một
cuốn sách mở với hiệu
ứng gợi ý màu xanh.
Sau khi thao tác, một
thông báo hiện lên và
người chơi bấm đồng ý.
Ký ức như những thước phim
quay chậm chợt ùa về. Một dự
án nghiên cứu đầy tham vọng...
một nguồn năng lượng mới... rồi
một tiếng nổ long trời lở đất...
Một phòng xem video
hiện lên để thể hiện ký
ức tái hiện làm tiền đề
cho nội dung cốt truyện
liên quan đến nguồn
năng lượng bền vững.
40
CHƯƠNG 3. PHƯƠNG PHÁP ĐỀ XUẤT
Kịch bản Thiết kế trong VR Hình ảnh trong VR
Màn chơi 1: Phân loại rác thải - Nạp năng lượng cho Aethos
"Đúng rồi... công nghệ tái chế
năng lượng... Aethos!" Kael thốt
lên, tia hy vọng lóe lên trong đôi
mắt mệt mỏi. "Đây chính là giải
pháp của chúng ta!" Cậu cẩn
thận nâng người bạn robot lên,
lách qua đống đổ nát để đặt
Aethos lên bệ năng lượng duy
nhất còn hoạt động. Giữa căn
phòng đổ nát, cỗ máy phân loại
và tái chế rác khổng lồ vẫn đứng
sừng sững. Kael hiểu rằng, đây
là cơ hội duy nhất để cứu
Aethos. Nhưng con đường đến
cỗ máy không hề dễ dàng, dây
điện đứt gãy chằng chịt khắp
nơi, thời gian thì không còn
nhiều. Kael buộc phải đứng từ
xa, ném những mảnh rác vào
đúng vị trí của máy phân loại với
hy vọng mong manh rằng,
nguồn năng lượng quý giá sẽ
được tái tạo kịp lúc.
Người chơi được đưa
vào căn phòng để thực
hiện nhiệm vụ. Căn
phòng được thiết kế như
kịch bản với robot ở bệ
năng lượng, các máy
phân loại rác giữa
phòng, rác thải xung
quanh và dây điện chằng
chịt.
Với bản năng của nhà khoa học,
Kael nhớ rõ được mình cần phải
phân loại rác thải thế nào.
Những kí ức của Kael về phân
loại rác hiện thoáng qua.
Người chơi tìm và bấm
nút xem hướng dẫn và
được chuyển đến phòng
xem video hướng dẫn.
Video hướng dẫn về
phân loại rác thải được
chiếu trong khoảng 60
giây và người chơi sau
đó quay lại phòng chính.
41
CHƯƠNG 3. PHƯƠNG PHÁP ĐỀ XUẤT
Kịch bản Thiết kế trong VR Hình ảnh trong VR
Sau khi lục lại trí nhớ, Kael bắt
đầu thực hiện ném rác sao cho
đúng vào thùng cần thiết để có
thể nhanh chóng tái tạo năng
lượng cho Aethos. Có nhiều vật
thể anh ấy ném chính xác, nhưng
cũng có cái Kael ném sai.
Nhưng cuối cùng, may mà năng
lượng đã đạt đến 100%
Màn hình tính điểm cho
việc ném rác đúng. Nếu
ném hết rác mà chưa đạt
100% thì cần chơi lại.
Sau khi đạt 100% thì
Aethos đứng dậy và có
thể di chuyển và trò
chuyện.
Màn chơi 2: Aethos thức tỉnh kỹ năng mới
"Aethos, cậu đã tỉnh rồi!" Kael
reo lên, vui sướng ôm chầm lấy
người bạn robot của mình. "Tôi
cứ tưởng...". Sau khi hỏi han
Aethos, Kael đi vào vấn đề
chính. "Cậu có biết chuyện gì đã
xảy ra với thế giới này không
Aethos? Và... làm thế nào mà
những loại rác thải tôi vừa phân
loại lại có thể tái chế thành năng
lượng được?" - Kael hỏi Aethos
Người chơi trỏ vào vật
thể trong môi trường và
chọn chức năng tìm hiểu
tái chế rác thải
42
CHƯƠNG 3. PHƯƠNG PHÁP ĐỀ XUẤT
Kịch bản Thiết kế trong VR Hình ảnh trong VR
Kael thở phào nhẹ nhõm: "Tôi
đã hiểu sơ bộ về tình hình thế
giới và nguồn năng lượng rồi.
Nhưng có vẻ nơi này, mọi thứ
đều sử dụng một ngôn ngữ khác,
tôi không hiểu rõ lắm."
Aethos vỗ nhẹ vào vai Kael,
giọng nói đều đều trấn an:
"Đừng lo, Kael. Tôi đã tập hợp
đủ năng lượng và có thể giúp
cậu hiểu thêm về ngôn ngữ của
thế giới này."
Trỏ vào vật thể trong
môi trường và chọn
chức năng học từ vựng
tiếng Pháp
Bảng 3.2: Kịch bản bài giảng Neo Terra
3.4 Mô hình hoá yêu cầu
Trong phần trên, tôi đã phân tích và đưa ra các yêu cầu cần thiết về các bài giảng
cho ứng dụng The VR Labs. Trong phần này, tôi sẽ mô hình hoá các yêu cầu đó
thông qua các biểu đồ ca sử dụng và biểu đồ hoạt động. Trong hệ thống The VR
Labs hiện tại, tác nhân chính là người học. Người học trong bối cảnh này hiểu là
người sử dụng hệ thống The VR Labs để học tập và trải nghiệm các bài giảng VR.
3.4.1 Biểu đồ ca sử dụng tổng quan
Biểu đồ ca sử dụng tổng quan được trình bày trong Hình 3.7 mô tả các tương
tác chính giữa người học và hệ thống The VR Labs. Ba ca sử dụng chính bao gồm
"Chọn bài giảng", "Trải nghiệm Network Lab" và "Trải nghiệm Neo Terra". Ca sử
dụng "Trải nghiệm lại bài học" mở rộng từ hai ca sử dụng trải nghiệm Network Lab
và Neo Terra. Điều này có nghĩa là sau khi hoàn thành bài giảng, người học có cơ
hội trải nghiệm lại, để có thể thử lại các bài giảng nhiều lần.
3.4.2 Biểu đồ ca sử dụng phân rã
Sau khi có biểu đồ ca sử dụng tổng quan như trong hình 3.7, đồ án tiếp tục thiết
kế các biểu đồ ca sử dụng phân rã cho từng bài giảng cụ thể. Hình 3.8 mô tả các ca
sử dụng của bài giảng Network Lab, trong đó người học sẽ được hướng dẫn cách
lắp đặt cáp mạng Ethernet từ việc gỡ xoắn dây, phân loại dây mạng, cắt dây mạng,
nối dây mạng và bấm đầu cáp mạng. Mỗi ca sử dụng tương ứng với một bước trong
quy trình lắp đặt cáp mạng, giúp người học hiểu rõ hơn về quy trình và cách thức
thực hiện một cách chính xác.
43
CHƯƠNG 3. PHƯƠNG PHÁP ĐỀ XUẤT
Hình 3.7: Biểu đồ ca sử dụng của hệ thống The VR Labs
Hình 3.9 mô tả ca sử dụng của bài giảng Neo Terra, trong đó người học sẽ được
hướng dẫn cách phân loại rác thải và tái chế rác thải thông qua trò chơi tương tác.
Bên cạnh xem video hướng dẫn để hiểu cốt truyện cũng như truyền tải kiến thức,
Neo Terra còn tích hợp thêm việc học từ vựng tiếng Pháp và tìm hiểu khả năng tái
chế thông qua tương tác với robot thông minh. Điều này giúp người học học ngoại
ngữ một cách tự nhiên và thú vị, đồng thời mở rộng kiến thức về công nghệ và môi
trường.
3.4.3 Biểu đồ hoạt động
Sau khi có biểu đồ ca sử dụng của hệ thống The VR Labs, tôi thiết kế biểu đồ
hoạt động thể hiện luồng hoạt động của hệ thống thông qua biểu đồ như trong Hình
3.10. Biểu đồ này mô tả các tương tác giữa người học và hệ thống The VR Labs, từ
việc chọn bài giảng, trải nghiệm Network Lab và Neo Terra, đến việc trải nghiệm
lại bài học. Biểu đồ hoạt động giúp việc thiết kế hệ thống rõ ràng hơn khi bắt đầu
lập trình.
44
CHƯƠNG 3. PHƯƠNG PHÁP ĐỀ XUẤT
Hình 3.8: Biểu đồ ca sử dụng của bài giảng Network Lab
Hình 3.9: Biểu đồ ca sử dụng của bài giảng Neo Terra
45
CHƯƠNG 3. PHƯƠNG PHÁP ĐỀ XUẤT
Hình 3.10: Biểu đồ hoạt động của The VR Labs
46
