CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
Chương 4 đã trình bày chi tiết về nền tảng lý thuyết làm cơ sở cho việc thiết kế
và phát triển hệ thống The VR Labs, bao gồm các lý thuyết học tập như học tập trải
nghiệm, học tập qua thử và sai, thuyết thất bại sản xuất, thuyết tự quyết, thuyết tải
nhận thức và lý thuyết trò chơi hóa. Việc áp dụng các lý thuyết này không chỉ giúp
tối ưu hóa trải nghiệm học tập của người dùng mà còn tạo ra một môi trường học
tập tương tác, hấp dẫn và hiệu quả.
Tiếp nối những phân tích lý thuyết này, chương 5 sẽ tập trung vào việc đánh giá
thực nghiệm hệ thống The VR Labs. Thông qua việc thiết kế chi tiết hệ thống, triển
khai thử nghiệm và thu thập dữ liệu từ người dùng, chương này sẽ đánh giá một
cách khách quan tính hiệu quả của The VR Labs trong việc nâng cao chất lượng
giáo dục thực hành.
5.1 Tổng quan
Chương này trình bày kết quả nghiên cứu nhằm đánh giá tính hiệu quả của việc
ứng dụng công nghệ thực tế ảo vào giảng dạy thực hành thông qua hệ thống The
VR Labs. Nghiên cứu tập trung vào hai bài giảng thực hành là Network Lab, mô
phỏng quy trình lắp đặt cáp mạng Ethernet, và Neo Terra, một bài giảng nâng cao
nhận thức về phát triển bền vững thông qua trò chơi hóa.
Nghiên cứu được thực hiện với 47 học viên với đa dạng bối cảnh. Các học viên
được trải nghiệm Network Lab và Neo Terra theo thứ tự. Dữ liệu được thu thập
thông qua nhiều phương pháp khác nhau, bao gồm khảo sát Likert và phỏng vấn
bán cấu trúc để đánh giá trải nghiệm và cảm nhận của người học đối với cả hai bài
giảng.
Kết quả nghiên cứu sẽ cung cấp cái nhìn khách quan về tác động của công nghệ
VR đến việc học tập và giảng dạy thực hành, đồng thời làm cơ sở cho việc cải tiến
và phát triển các ứng dụng VR trong tương lai.
5.2 Triển khai Hệ thống
5.2.1 Giao diện và triển khai thực tế của The VR Labs
Trong quá trình phát triển The VR Labs, tôi đã thiết kế và triển khai các giao
diện cho môi trường học tập ảo. Hình phác thảo 5.1 và giao diện thực tế 5.2 thể
hiện giao diện chính của The VR Labs, nơi người dùng có thể chọn bài giảng thực
hành. Hình 5.3 và 5.4 lần lượt cho thấy ý tưởng của thiết kế giao diện của bài giảng
Network Lab và Neo Terra. Từ việc phác hoạ ý tưởng, giao diện thực tế được mô tả
tại Hình 5.5 và 5.6.
58
CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
Hình 5.1: Phác thảo giao diện chính của The VR Labs
Hình 5.2: Giao diện đã triển khai trong môi trường VR
59
CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
Hình 5.3: Phác thảo giao diện cho bài giảng Network Lab
Hình 5.4: Phác thảo giao diện cho bài giảng Neo Terra
60
CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
Hình 5.5: Giao diện đã triển khai cho bài giảng Network Lab
Hình 5.6: Giao diện đã triển khai cho bài giảng Neo Terra
61
CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
Về thiết kế vật thể 3D, kìm bấm mạng trong Network Lab được thiết kế để thực
hiện ba bước chính trong quá trình kết nối dây mạng với hạt mạng. Như minh họa
trong Hình 5.7, kìm bấm mạng bao gồm ba bộ phận chính.
Phần đầu tiên của kìm có lưỡi dao lớn hơn, được sử dụng để cắt đứt dây mạng
theo chiều dài mong muốn, đảm bảo độ chính xác và tính thẩm mỹ. Tiếp theo, phần
giữa của kìm có lưỡi dao sắc bén, cho phép cắt và loại bỏ lớp vỏ nhựa bên ngoài
của dây mạng, để lộ ra các sợi dây đồng bên trong. Cuối cùng, sau khi hạt mạng
được kết nối với dây mạng, đầu dây mạng được đặt vào phần cuối của kìm và kìm
được bấm lại. Phần này có các rãnh và lưỡi dao đặc biệt, giúp bấm chặt hạt mạng
vào đầu dây mạng, đảm bảo kết nối chắc chắn và ổn định.
Hình 5.7: Thiết kế kìm bấm mạng trong Network Lab
Hình 5.8 minh họa hai trạng thái của dây mạng. Ở trạng thái chưa gỡ xoắn, các
sợi dây đồng bên trong được sắp xếp gọn gàng và xoắn chặt với nhau, được bao
bọc bởi lớp vỏ nhựa màu xanh dương. Khi gỡ xoắn, lớp vỏ nhựa được bóc ra một
phần, để lộ các sợi dây đồng bên trong với nhiều màu sắc khác nhau, bao gồm cả

```
dây đơn màu và dây hai màu (kết hợp với màu trắng). Chú thích bên cạnh hình ảnh
```

cũng giải thích rằng dây mạng có các màu sắc đa dạng như trong thực tế.
Trong thiết kế của Neo Terra, việc thiết kế nhân vật đòi hỏi nhiều công sức hơn
để diễn tả được cốt truyện.
Hình 5.9 trình bày quy trình thiết kế nhân vật 3D trong môi trường thực tế ảo
với sự hỗ trợ của trí tuệ nhân tạo được ứng dụng trong trò chơi Neo Terra. Đầu tiên,
người dùng cung cấp ý tưởng thiết kế nhân vật cho AI thông qua các công cụ tạo
62
CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
Hình 5.8: Thiết kế kìm dây mạng trong Network Lab

```
prompt. Sau đó, AI (Meshy AI) dựa trên ý tưởng này để tạo ra mô hình 3D của
```

```
nhân vật, đồng thời tạo sẵn texture (chất liệu bề mặt) cho mô hình. Tiếp theo, mô
```

hình 3D được tinh chỉnh trong Blender, một phần mềm 3D chuyên nghiệp, để đảm
bảo chất lượng và độ chi tiết. Texture 2D có thể được chỉnh sửa bằng Canva, một
công cụ thiết kế đồ họa trực tuyến, để tạo ra các hiệu ứng hình ảnh mong muốn.

```
Sau đó, mô hình 3D được tích hợp khung xương chuyển động (rigging) và hoạt ảnh
```

```
(animation) trong Unity hoặc Mixamo, cho phép nhân vật thực hiện các hành động
```

trong môi trường thực tế ảo. Cuối cùng, mô hình 3D đã hoạt động được kiểm tra và
hoàn thiện để sẵn sàng sử dụng trong môi trường thực tế ảo của trò chơi Neo Terra.
Nhờ sự hỗ trợ của AI, quy trình thiết kế nhân vật 3D trở nên nhanh chóng và hiệu
quả hơn, giúp người dùng dễ dàng tạo ra các nhân vật 3D chất lượng cao, đáp ứng
yêu cầu của trò chơi Neo Terra.
Đối với thiết kế nhân vật chính Kael, Hình 5.10 minh họa ý tưởng thiết kế ban
đầu. Kael được phác thảo với dáng đứng chữ T, chân rộng bằng vai, để dễ dàng
thêm khung xương và cử chỉ. Kael có mái tóc vàng bạch kim, mặc trang phục áo
blouse trắng của phòng thí nghiệm, nhấn mạnh vai trò của nhân vật trong việc
khám phá và bảo vệ thế giới. Phong cách thiết kế tổng thể của Kael là phong cách
hoạt hình, tạo cảm giác thân thiện và gần gũi với người chơi và đối tượng mà bài
giảng hướng đến phần lớn là người trẻ. Cái tên Kael có nguồn gốc Celtic và mang ý
nghĩa là "người bảo vệ mạnh mẽ", trong bối cảnh của trò chơi Neo Terra, tên nhân
vật ngụ ý rằng đây là "người bảo vệ và cứu tinh của Trái Đất".
63
CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
Hình 5.9: Quy trình thiết kế nhân vật 3D trong môi trường thực tế ảo với sự hỗ trợ của AI
Hình 5.10: Thiết kế Kael - Nhân vật chính
Về thiết kế robot đồng hành Aethos, hình 5.11 giới thiệu ý tưởng thiết kế cho
Aethos, robot đồng hành cùng Kael trong suốt cuộc hành trình. Aethos được tạo
hình với vẻ ngoài nhỏ nhắn, đáng yêu, linh hoạt, và mang đậm tính công nghệ. Nó
có đầu to, tròn và nhẵn, thân hình tròn trịa màu trắng với các điểm nhấn màu xanh
lá. Aethos được thiết kế theo phong cách hoạt hình vui nhộn và ngộ nghĩnh. Aethos
được trang bị màn hình hiển thị thông tin, cánh tay robot đa năng để hỗ trợ và tương
tác với Kael trong suốt cuộc hành trình. Tên Aethos được phát âm là /a.e.tos/ trong
tiếng Pháp, nghe giống như "A E Tốt" trong tiếng Việt, có nghĩa là "bạn tốt" hoặc
"bạn thân".
Trong màn chơi phân loại rác của Neo Terra, có rất nhiều vật thể 3D cần thiết kế,
tuy nhiên việc tinh chỉnh các thùng rác sao cho đúng màu sắc, thể hiện được thùng
này chứa loại rác nào là vô cùng cần thiết để cho người chơi có thể trải nghiệm học
64
CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
Hình 5.11: Thiết kế Aethos - Robot đồng hành
khám phá. Hình 5.12 mô tả các thùng rác được thiết kế trong môi trường thực tế
ảo của Neo Terra, các thùng rác này dùng chung một mô hình 3D, nhưng có các

```
nguyên liệu trong Unity (material) với màu sắc khác nhau. Trên mỗi thùng rác đều
```

có biểu tưởng để người học dễ dàng phát huy khả năng liên tưởng của mình.
Hình 5.12: Thiết kế thùng rác trong Neo Terra
5.2.2 Các module có thể tái sử dụng
Để giảm thời gian và công sức phát triển các bài giảng thực tế ảo tương tự trong
tương lai, một số module có khả năng tái sử dụng đã được phát triển trong quá trình
xây dựng The VR Labs. Các module này đóng vai trò như các khối xây dựng cơ
bản, cung cấp các chức năng cốt lõi cần thiết cho một ứng dụng VR giáo dục, giúp
các nhà phát triển khác có thể dễ dàng tùy chỉnh và tích hợp vào các dự án của
riêng mình.
Đầu tiên, module "Input Manager" được phát triển để đơn giản hóa việc tạo ra
65
CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
một ứng dụng VR. Module này bao gồm các thành phần cần thiết như VR Origin,
các vật thể bàn tay và cấu hình tương tác, giúp giảm thiểu thời gian và công sức
cần thiết để thiết lập môi trường VR cơ bản. Thao tác cầm nắm và mô hình bàn tay
trong module này được phát triển bởi nhóm BKVerse tại Edtech Center, ĐHBK Hà
Nội [60].
Hình 5.13: Module InputManager
Một module khác có khả năng ứng dụng rộng rãi là "AudioTextManager". Mod-
ule này được thiết kế để hỗ trợ việc hướng dẫn trong môi trường VR một cách trực
quan và hiệu quả bằng cách đồng bộ hóa lời nói, văn bản hướng dẫn và cử chỉ của

```
robot hướng dẫn (Hình 5.14). Cơ chế này cho phép người phát triển ứng dụng VR
```

tạo ra các cặp âm thanh-văn bản-cử chỉ một cách linh hoạt, mỗi cặp bao gồm một
đoạn âm thanh hướng dẫn, văn bản hiển thị trên màn hình, và một cử chỉ tương ứng
của robot, được sắp xếp theo một trình tự logic và kích hoạt tuần tự trong quá trình
hướng dẫn. Điều này không chỉ tăng cường khả năng tương tác và hiệu quả truyền
đạt thông tin mà còn cho phép người phát triển tùy chỉnh nội dung hướng dẫn để
phù hợp với từng bài giảng cụ thể. Hơn nữa, module "AudioTextManager" được
thiết kế để có khả năng tương thích với nhiều mô hình robot khác nhau, qua đó mở
rộng khả năng ứng dụng của nó trong một loạt các bối cảnh giáo dục và hướng dẫn
trong VR.
Trong quá trình nghiên cứu và phát triển hệ thống robot tương tác, việc tích hợp
trí tuệ nhân tạo để tạo ra các hành vi phức tạp và tự nhiên cho robot là rất cần thiết.
Để đạt được điều này, module "AethosController" đã được phát triển, sử dụng mô

```
hình toán học máy trạng thái hữu hạn (Finite State Machine - FSM) để quản lý các
```

trạng thái và hành vi của robot. FSM cho phép robot chuyển đổi linh hoạt giữa các

```
trạng thái khác nhau (như đứng yên, di chuyển, nói chuyện) dựa trên các sự kiện
```

hoặc tương tác với người dùng.
Module AethosController không chỉ hỗ trợ việc quản lý trạng thái và chuyển đổi
66
CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
Hình 5.14: Module AudioTextManager
hành vi của robot mà còn cung cấp một giao diện trực quan trong Unity Inspector.
Giao diện này cho phép người phát triển dễ dàng cấu hình và tùy chỉnh các tham số
quan trọng. Các tham số này bao gồm Navmesh Agent giúp robot di chuyển thông
minh trong môi trường 3D. Animator điều khiển các chuyển động và biểu cảm của
robot. TTS Module chứa các đoạn âm thanh mà robot sẽ phát ra, giúp robot có thể
"nói chuyện" với người dùng. Scan Module xử lý việc quét và nhận diện vật thể
trong môi trường, cho phép robot tương tác với các đối tượng cụ thể.
Bằng cách thay đổi các tham số này, nhà phát triển có thể dễ dàng tùy chỉnh
hành vi của robot Aethos hoặc bất kỳ robot nào khác để phù hợp với yêu cầu của
từng bài giảng cụ thể. Ví dụ, trong bài giảng Neo Terra, robot Aethos được lập trình
để di chuyển đến các vị trí khác nhau, tương tác với người dùng thông qua giọng
nói và cử chỉ, quét các vật thể để cung cấp thông tin và tham gia vào các trò chơi
giáo dục.
Nhờ vào tính linh hoạt và khả năng tùy chỉnh cao, AethosController có tiềm
năng ứng dụng rộng rãi trong nhiều lĩnh vực, từ giáo dục đến giải trí, đồng thời
nâng cao hiệu quả và chất lượng của tương tác giữa robot và người dùng.
Để tích hợp trí tuệ nhân tạo tạo sinh vào Unity, quy trình được mô tả trong hình

```
5.16 bao gồm các bước sau: (i) nhập hình ảnh của vật thể vào hệ thống, (ii) xử
```

```
lý hình ảnh bằng Gemini Module (gemini-pro-1.5-model) với khả năng tùy chỉnh
```

```
prompt để đáp ứng yêu cầu cụ thể, (iii) chuyển đổi văn bản mô tả được tạo ra từ
```

```
Gemini Module thành âm thanh bằng Text-To-Speech Module (sử dụng Google
```

```
Text-to-Speech), và (iv) đầu ra cuối cùng là âm thanh, được sử dụng để phát trong
```

môi trường thực tế ảo, tạo điều kiện cho việc tương tác tự nhiên hơn và cung cấp
thông tin hoặc hướng dẫn dựa trên vật thể được quét.
67
CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
Hình 5.15: Module AethosController
Hình 5.16: Gemini Module
5.2.3 Triển khai và khảo sát The VR Labs
Việc triển khai và khảo sát The VR Labs được thực hiện liên tục và cải thiện qua
từng phiên bản. Đầu tiên, khung lý thuyết và ý tưởng cho việc ứng dụng đã được
trình bày tại Hội nghị Sinh viên Nghiên cứu khoa học lần thứ 40 tại Trường Công
nghệ Thông tin và Truyền thông, Đại học Bách khoa Hà Nội vào tháng 4/2023, với
đề tài "Đề xuất giải pháp nâng cao chất lượng giảng dạy thực hành ứng dụng công
nghệ thực tế ảo". Hình 5.17 minh họa poster được trình bày tại hội nghị. Sau khi
tiếp thu những ý kiến của hội đồng ban giám khảo, tôi đã tiếp tục phát triển và ứng
dụng thêm các lý thuyết vào hệ thống The VR Labs, đã được trình bày trong đồ án
này.
Ứng dụng Network Lab được triển khai và giới thiệu lần đầu vào tháng 6/2023
tại Trường Công nghệ Thông tin và Truyền thông, Đại học Bách khoa Hà Nội. Buổi
triển lãm, minh họa trong hình 5.18, đã thu hút sự quan tâm của đông đảo học sinh,
sinh viên và các giáo viên THPT. Tại đây, người học được hướng dẫn sử dụng kính
thực tế ảo để trải nghiệm bài giảng Network Lab, bao gồm cả phần thực hành lắp
đặt cáp mạng Ethernet trong môi trường VR. Người tham gia được hướng dẫn sử
dụng kính thực tế ảo để trải nghiệm bài giảng, bao gồm phần thực hành lắp đặt cáp

```
mạng Ethernet trong môi trường VR. Poster hướng dẫn (Hình ??) đã được sử dụng
```

trong các buổi triển lãm này. Sau buổi triển lãm trải nghiệm, một số lưu ý về tính
tương tác và sự phản hồi của hệ thống đã được ghi nhận và được cải thiện trong các
phiên bản sau.
68
CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
Đối với Neo Terra, một phần ý tưởng và bản chạy thử đã được trình bày trước hội

```
đồng Tổ chức Quốc tế Pháp ngữ (OIF) vào tháng 6/2024 trong khuôn khổ cuộc thi
```

Hackathon "Jeu Parle Franc¸ais" và nhận được nhiều đánh giá cao trong việc nâng
cao nhận thức phát triển bền vững thông qua trò chơi nghiêm túc nhằm mục đích
thực hiện 17 mục tiêu phát triển bền vững của Liên Hợp Quốc. Hình 5.20 minh hoạ
việc thuyết trình tính khả thi của ý tưởng Neo Terra trước Tổ chức Quốc tế Pháp
ngữ [17]. Sau khi nhận được góp ý và nhận xét, việc cải thiện các yếu tố trò chơi
và trải nghiệm trong Neo Terra đã được triển khai và trình bày trong đồ án này.
Tháng 6/2024, The VR Labs đã được triển khai đầy đủ trên kính thực tế ảo Pico
4 và Oculus Quest 2 bao gồm cả Network Lab và Neo Terra. Một buổi khảo sát
khác được tổ chức để đánh giá toàn diện hệ thống với sự tham gia của 48 người với

```
các bối cảnh giáo dục khác nhau (Hình 5.21). Buổi khảo sát có sự tham gia và góp
```

ý của TS. Nguyễn An Hưng, giảng viên phụ trách học phần Thực hành Mạng máy
tính.
69
CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
Hình 5.17: Poster trình bày đề tài "Đề xuất giải pháp nâng cao chất lượng giảng dạy thực
hành ứng dụng công nghệ thực tế ảo" tại Hội nghị Sinh viên Nghiên cứu khoa học lần thứ
40
70
CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
Hình 5.18: Buổi triển lãm về bài giảng Network Lab tại Trường Công nghệ Thông tin và
Truyền thông, Đại học Bách khoa Hà Nội, tháng 6/2023. Nguồn: Fanpage DaoTao.ai [61]
Hình 5.19: Poster hướng dẫn sử dụng ứng dụng Network Lab
71
CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
Hình 5.20: Trình bày ý tưởng và một phần chương trình Neo Terra tại cuộc thi do Tổ chức
Quốc tế Pháp ngữ tổ chức. [17]
Hình 5.21: Một số hình ảnh về việc thu thập khảo sát ứng dụng The VR Labs dưới sự
tham gia và góp ý của giảng viên phụ trách học phần Thực hành Mạng máy tính vào tháng
6/2024.
72
CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
5.3 Phân tích khảo sát The VR Labs
5.3.1 Phương pháp thu thập dữ liệu
Trong nghiên cứu này, tôi đã tiến hành một khảo sát cho The VR Labs để đánh
giá hiệu quả của các bài giảng thực hành trong môi trường thực tế ảo. Để thu thập
dữ liệu một cách hiệu quả, tôi đã áp dụng một phương pháp tiếp cận kết hợp, sử
dụng cả thang đo Likert 5 mức độ và phỏng vấn bán cấu trúc. Thang đo Likert, với
các mức độ từ "1 - Hoàn toàn không đồng ý", "2 - Không đồng ý", "3 - Không ý
kiến", "4 - Đồng ý" đến "5 - Hoàn toàn đồng ý", cho phép đo lường mức độ tự tin
của học viên trong việc thực hiện các nhiệm vụ liên quan đến khóa học một cách
định lượng. Thông tin chi tiết của nội dung khảo sát xem tại phụ lục B B. Bên cạnh
đó, phỏng vấn bán cấu trúc mang lại cái nhìn sâu sắc hơn về trải nghiệm và cảm
nhận của học viên, cung cấp dữ liệu định tính bổ sung giúp tôi hiểu rõ hơn về các
yếu tố ảnh hưởng đến sự tự tin, hài lòng, hứng thú và hiệu quả học tập.
Các câu hỏi trong thang đo Likert được thiết kế dựa trên mục tiêu học tập và kỹ
năng cần đạt được từ các bài giảng, đặc biệt là Network Lab và Neo Terra. Chúng
tập trung vào việc đánh giá tính thực hành, thời gian hiểu để thực hành, khả năng
ghi nhớ kiến thức, cũng như tính hứng thú, động lực và kiến thức thu được từ các
bài giảng. Ngoài ra, tôi cũng đánh giá khả năng hiểu và áp dụng kiến thức, tự học,
làm việc nhóm, trình bày ý kiến, đánh giá và phản hồi của học viên.
Quy trình khảo sát bao gồm việc 48 người học đã hoàn thành các bài giảng thực
hành tham gia khảo sát, thực hiện bài kiểm tra để đánh giá khách quan tính hiệu
quả của bài giảng, trả lời thang đo Likert và tham gia phỏng vấn bán cấu trúc. Dữ
liệu thu thập được từ cả hai phương pháp sau đó được phân tích để đánh giá toàn
diện hiệu quả của bài giảng và xác định các lĩnh vực cần cải thiện. Quy trình khảo
sát và phân tích dữ liệu thực nghiệm được mô tả chi tiết tại Hình 5.22.
Phân tích dữ liệu định lượng từ thang đo Likert giúp tôi xác định mức độ tự tin
tổng thể của học viên và so sánh mức độ tự tin giữa các khía cạnh khác nhau của
trải nghiệm học tập. Đồng thời, phân tích dữ liệu định tính từ phỏng vấn bán cấu
trúc cho phép tôi xác định các chủ đề và mô hình nổi bật, mang lại cái nhìn sâu sắc
và toàn diện về trải nghiệm học tập của học viên tại The VR Labs.
Độ tin cậy nội bộ của thang đo Likert được đánh giá bằng hệ số Cronbach’s

```
alpha α. Giá trị của α càng cao (tối đa là 1), cho thấy độ tin cậy của thang đo càng
```

lớn, đồng nghĩa với việc các câu hỏi trong thang đo đều đo lường một khái niệm
thống nhất và có độ tin cậy cao.
73
CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
Hình 5.22: Quy trình khảo sát và phân tích dữ liệu thực nghiệm
Công thức tính Cronbach’s alpha được mô tả như sau:
α =

k
k − 1
 "
1 −
Pk

```
i=1 Var(Xi)
```

```
Var(Xtotal)
```

#

Hệ số Cronbach’s alpha α được tính toán dựa trên số lượng câu hỏi k, phương

```
sai của mỗi câu hỏi Var(Xi), và phương sai của tổng điểm của tất cả các câu hỏi
```

```
Var(Xtotal).
```

Để tính toán hệ số Cronbach’s alpha, chúng ta cần thực hiện một quy trình gồm

```
bốn bước. Đầu tiên, tính toán phương sai Var(Xi) của từng câu hỏi trong thang đo.
```

Phương sai này phản ánh mức độ phân tán của các câu trả lời cho mỗi câu hỏi cụ
thể. Tiếp theo, tổng phương sai của tất cả các câu hỏi
P

```
Var(Xi) được tính bằng
```

cách cộng các phương sai riêng lẻ của từng câu hỏi. Sau đó, phương sai của tổng

```
điểm Var(Xtotal) được xác định, thể hiện mức độ phân tán của tổng số điểm mà mỗi
```

người trả lời đạt được trên toàn bộ thang đo. Cuối cùng, bằng cách thay các giá trị

```
đã tính được k, Var(Xi), Var(Xtotal) vào công thức Cronbach’s alpha, chúng ta sẽ
```

có được một ước lượng định lượng về độ tin cậy của thang đo Likert đang được sử
dụng.
5.3.2 Phân tích kết quả
Việc trải nghiệm và tham gia khảo sát được thực hiện bởi 48 người. Đối tượng
chủ yếu là sinh viên đại học, chiếm 87,2%, với tỷ lệ lớn nhất là sinh viên năm hai

```
(40,4%). Điều này cung cấp một cái nhìn đa dạng về cách tiếp cận và trải nghiệm
```

VR trong môi trường giáo dục, từ sinh viên đại học đến học sinh THPT và giáo
viên.
Phân tích về mức độ quen thuộc với thiết bị VR cho thấy một sự phân chia rõ
rệt: 45,8% số người tham gia khảo sát chưa từng trải nghiệm VR, trong khi 54,2%
đã có kinh nghiệm sử dụng VR trước đây. Đáng chú ý, quá trình làm quen với thiết
bị VR thường mất khoảng 5 đến 10 phút cho những người mới sử dụng lần đầu.
74
CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
Tuy nhiên, qua phỏng vấn, tôi nhận thấy rằng những người thường xuyên chơi trò
chơi điện tử có khả năng thích nghi nhanh hơn so với những người ít chơi hoặc
không chơi trò chơi điện tử. Điều này có thể được giải thích bởi việc trải nghiệm
người dùng trong các trò chơi điện tử và môi trường VR có nhiều điểm chung, giúp
họ dễ dàng thích nghi với thiết bị VR. Những người đã từng sử dụng thiết bị VR
trước đây mất trung bình 20,88 phút và trung vị là 10 phút để làm quen với thiết bị.
Những số liệu này cho thấy việc làm quen với thiết bị VR không quá khó khăn dù
đối với người lần đầu sử dụng công nghệ này.
Đối với bài giảng thực hành lắp dây mạng Network Lab, kết quả cho thấy có
58,3% người được hỏi chưa từng học lắp dây mạng trước đây, trong khi 41,7% đã
từng học. Điều này cho thấy nhu cầu tìm hiểu về lắp đặt dây mạng khá cao, đặc
biệt đối với sinh viên Công nghệ thông tin.
Khi được hỏi về kỳ vọng của người học đối với bài giảng lắp đặt dây mạng,
các yêu cầu hàng đầu bao gồm mong muốn áp dụng kiến thức vào thực tế, hiểu rõ
nguyên lý và thực hành thành thạo, cũng như nhận được bài giảng chi tiết, rõ ràng
và dễ hiểu. Người học cũng đánh giá cao tính thực tế, trực quan của bài giảng, và
mong muốn có tính tương tác cao, kiến thức bổ sung về mạng máy tính, cũng như
hỗ trợ đa ngôn ngữ để mở rộng tiếp cận. Điều này cho thấy nhu cầu về một bài
giảng lắp dây mạng không chỉ truyền đạt kiến thức mà còn phải thực tế, tương tác
và dễ tiếp cận cho mọi người.
Đầu tiên, người tham gia được trải nghiệm tự học thông qua bài giảng truyền
thống theo định dạng 2D qua video và tài liệu dạng PDF. Nội dung chi tiết được
mô tả như trong bảng 5.1. Tổng thể, bài giảng 2D được đánh giá tích cực về việc
cung cấp tài liệu, sự hiểu biết và tự do trong học tập. Tuy nhiên, vẫn cần có sự cải
thiện trong việc giúp người học cảm thấy tự tin hơn về khả năng áp dụng kiến thức
vào thực tế và cân nhắc về mức độ cần thiết của việc ghi chép cho mọi người. Có
thể xem xét việc tích hợp thêm các phương pháp học tập tương tác, như mô phỏng
hoặc thực hành thực tế, để tăng cường hiệu quả của bài giảng.
STT Câu hỏi khảo sát Điểm
trung
bình
Độ lệch
chuẩn
1 Đọc tài liệu và xem video nhiều lần 3.94 0.81
2 Ghi chép lại các bước thực hiện 3.7 1.05
3 Hiểu rõ các bước thực hiện trong quy trình lắp đặt cáp
Ethernet
3.77 1.07
Tiếp tục trên trang sau
75
CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
Bảng 5.1 – tiếp theo từ trang trước
STT Câu hỏi khảo sát Điểm
trung
bình
Độ lệch
chuẩn
4 Tìm hiểu thêm thông tin về lắp đặt cáp Ethernet 3.71 1.11
5 Có quyền tự do lựa chọn cách học và tốc độ học 3.96 1.09
6 Học qua tài liệu 2D chuẩn bị cho thực hành thực tế 3.63 1.08
7 Không gặp khó khăn trong việc hiểu và ghi nhớ các
bước
3.48 1.11
8 Bài giảng 2D cung cấp đủ thông tin để thực hành thực
tế
3.74 1.01
Bảng 5.1: Tự đánh giá của người học sau khi học bài giảng 2D về lắp đặt cáp Ethernet
Bảng 5.2 mô tả lại kết quả tính toán trên thang Likert về sự đánh giá của người
học sau khi trải nghiệm ứng dụng Network Lab trong môi trường thực tế ảo. Kết
quả khảo sát về bài thực hành Network Lab đã cho thấy hiệu quả vượt trội của
công nghệ thực tế ảo trong việc đào tạo kỹ thuật lắp đặt cáp Ethernet. Người học
không chỉ nắm vững kiến thức lý thuyết mà còn tự tin áp dụng vào thực tế, thể
hiện qua khả năng thực hành thành thạo và giải quyết các tình huống khác nhau.
VR mang đến trải nghiệm học tập tương tác, thú vị và hiệu quả hơn so với phương
pháp truyền thống, giúp người học chủ động khám phá và tiếp thu kiến thức một
cách linh hoạt. Sự mô phỏng chân thực môi trường làm việc và phản hồi tức thì từ
hệ thống giúp người học nhanh chóng nhận biết và sửa lỗi, từ đó nâng cao kỹ năng
một cách hiệu quả. Network Lab đã chứng minh tiềm năng to lớn của VR trong
việc đổi mới sáng tạo phương pháp đào tạo kỹ thuật, mang đến giải pháp học tập
trải nghiệm tốt hơn và hiệu quả hơn cho người dùng.
STT Câu hỏi khảo sát Điểm
trung
bình
Độ lệch
chuẩn
1 Tôi đã thực hành lắp đặt cáp Ethernet nhiều lần trong
môi trường VR.
3.98 0.91
2 Tôi hiểu rõ các bước thực hiện trong quy trình lắp đặt
cáp Ethernet.
4.25 0.81
3 Tôi có thể xác định và sửa chữa các lỗi thường gặp
trong quá trình lắp đặt cáp Ethernet.
4.10 0.75
Tiếp tục trên trang sau
76
CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
Bảng 5.2 – tiếp theo từ trang trước
STT Câu hỏi khảo sát Điểm
trung
bình
Độ lệch
chuẩn
4 Tôi có thể áp dụng kiến thức đã học để giải quyết các
tình huống lắp đặt cáp Ethernet khác nhau.
4.23 0.63
5 Tôi đã tìm kiếm thêm thông tin về lắp đặt cáp Ethernet
từ các nguồn khác nhau.
4.08 0.85
6 Tôi cảm thấy bài thực hành VR là một trải nghiệm học
tập thực tế và hữu ích.
4.45 0.72
7 Tôi cảm thấy tự tin hơn khi thực hành lắp đặt cáp Eth-
ernet trên thiết bị thật sau khi trải nghiệm VR.
4.38 0.67
8 Tôi cảm thấy có quyền tự do lựa chọn cách học và thực
hành trong môi trường VR.
4.31 0.75
9 Tôi cảm thấy bài thực hành VR giúp tôi nâng cao năng
lực lắp đặt cáp Ethernet.
4.33 0.72
10 Tôi tin rằng việc thực hành trong VR sẽ giúp tôi tự tin
hơn khi làm việc với các thiết bị mạng thật.
4.33 0.81
11 Các yếu tố như điểm số, huy hiệu, bảng xếp hạng giúp
tôi có thêm động lực để thực hành trong VR.
4.15 0.85
12 Tôi cảm thấy tự tin hơn khi thực hiện các thao tác lắp
đặt cáp Ethernet sau khi xem hướng dẫn và ví dụ trong
VR.
4.42 0.61
13 Tôi cảm thấy lượng thông tin trong bài thực hành VR
vừa đủ, không quá nhiều hoặc quá ít.
4.35 0.64
14 Tôi cảm thấy các thiết bị và công cụ trong VR giống
với những gì tôi sử dụng trong thực tế.
4.08 0.87
15 Tôi cảm thấy tự tin hơn trong việc áp dụng kiến thức
vào các tình huống thực tế sau khi thực hành trong
VR.
4.19 0.84
16 Tôi cảm thấy VR tạo điều kiện cho việc tự học và
khám phá kiến thức một cách linh hoạt.
4.35 0.73
17 Tôi cảm thấy các tương tác trong VR mô phỏng chân
thực các thao tác kỹ thuật trong lắp đặt và cấu hình
mạng.
4.29 0.74
Tiếp tục trên trang sau
77
CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
Bảng 5.2 – tiếp theo từ trang trước
STT Câu hỏi khảo sát Điểm
trung
bình
Độ lệch
chuẩn
18 Tôi cảm thấy môi trường VR cung cấp phản hồi kịp
thời và chính xác, giúp tôi hiểu được các sai sót và
cách khắc phục.
4.31 0.66
19 Tôi cảm thấy việc sử dụng VR trong học tập tạo ra
một trải nghiệm học tập thú vị và tương tác cao.
4.44 0.68
20 Tôi thấy việc học lắp đặt cáp Ethernet trong VR hiệu
quả hơn so với việc chỉ học lý thuyết và thực hành trên
thiết bị thật.
4.35 0.73
21 Tôi thích học lắp đặt cáp Ethernet trong VR hơn so
với việc học lý thuyết và thực hành trên thiết bị thật.
4.40 0.64
22 Bài thực hành VR có độ khó phù hợp với trình độ của
tôi.
4.15 0.71
Bảng 5.2: Tự đánh giá của người học sau khi học bài giảng 3D - Network Lab
Sau khi tự học theo phương pháp 2D, thời gian trung bình để người học hoàn
thành bài thực hành là 24,3 phút, với trung vị là 20 phút. Tuy nhiên, cũng có người
không hoàn thành được bài thực hành. Ngược lại, sau khi tự học theo phương pháp
3D, thời gian hoàn thành trung bình giảm đáng kể xuống còn 15,28 phút, với trung
vị là 11 phút. Điều này cho thấy phương pháp 3D có thể giúp người học tiếp thu
kiến thức và thực hành hiệu quả hơn, rút ngắn thời gian hoàn thành và giảm bớt
khó khăn trong quá trình học tập.
Tiếp theo có 43/48 người học trải nghiệm Neo terra. Bảng 5.3 tổng hợp đánh
giá của người học về hiệu quả giáo dục của bài giảng thực tế ảo "Neo Terra" trong
việc nâng cao nhận thức về phân loại rác và bảo vệ môi trường. Kết quả cho thấy
phần lớn người học đều đánh giá cao bài giảng này, thể hiện qua điểm trung bình

```
cao (> 4) ở hầu hết các câu hỏi.
```

Đặc biệt, các câu hỏi liên quan đến nhận thức về tầm quan trọng của phân loại
rác và trách nhiệm bảo vệ môi trường sau bài giảng đạt điểm số rất cao, chứng tỏ
tác động mạnh mẽ của phương pháp giáo dục này. Bên cạnh đó, độ lệch chuẩn thấp
cho thấy sự đồng thuận cao trong các phản hồi, củng cố thêm kết luận rằng bài
giảng "Neo Terra" đã thực sự hiệu quả.
Phân tích kết quả khảo sát cho thấy mô hình giáo dục thực tế ảo "Neo Terra" đã
78
CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
tạo ra những ảnh hưởng tích cực, giúp người học hiểu sâu hơn về vấn đề môi trường
thông qua trải nghiệm giáo dục trực quan và tương tác. Điều này mở ra tiềm năng
to lớn cho việc ứng dụng công nghệ thực tế ảo trong giáo dục, đặc biệt là trong các
lĩnh vực liên quan đến môi trường và phát triển bền vững.
STT Câu hỏi khảo sát Điểm
trung
bình
Độ lệch
chuẩn
1 Tôi đã thực hành phân loại rác nhiều lần trong môi
trường VR.
4.09 0.78
2 Tôi nhận được phản hồi ngay lập tức về việc phân loại
rác đúng hay sai.
4.37 0.63
3 Việc thực hành lặp đi lặp lại trong VR giúp tôi phân
loại rác tốt hơn.
4.37 0.65
4 Tôi hiểu rõ các loại rác và cách phân loại chúng sau
bài giảng.
4.37 0.62
5 Tôi có thể giải thích tại sao việc phân loại rác lại quan
trọng.
4.35 0.69
6 Tôi có thể phân biệt được sự phân loại các loại rác
thải.
4.40 0.66
7 Tôi đã chủ động tìm hiểu thêm thông tin về tái chế và
phát triển bền vững sau bài giảng.
4.21 0.77
8 Tôi có thể áp dụng kiến thức đã học để đề xuất các giải
pháp giảm thiểu rác thải trong cuộc sống hàng ngày.
4.16 0.65
9 Tôi đã tìm kiếm thêm thông tin về tái chế và phát triển
bền vững từ các nguồn khác nhau.
4.23 0.72
10 Tôi sẽ chia sẻ và thảo luận với người khác về vấn đề
tái chế và phát triển bền vững.
4.23 0.78
11 Bài giảng Neo Terra giúp tôi hiểu rõ hơn về tác động
của rác thải đến môi trường.
4.35 0.65
12 Tôi cảm thấy có trách nhiệm hơn trong việc bảo vệ
môi trường sau bài giảng.
4.40 0.59
13 Tôi cảm thấy bài giảng Neo Terra khơi dậy sự quan
tâm của tôi đến vấn đề môi trường.
4.30 0.65
14 Tôi cảm thấy có động lực để tìm hiểu thêm về phát
triển bền vững.
4.28 0.71
Tiếp tục trên trang sau
79
CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
Bảng 5.3 – tiếp theo từ trang trước
STT Câu hỏi khảo sát Điểm
trung
bình
Độ lệch
chuẩn
15 Tôi cảm thấy bài giảng Neo Terra cho tôi quyền tự do
khám phá và tìm hiểu theo cách riêng của mình.
4.19 0.62
16 Tôi tin rằng việc phân loại rác đúng cách sẽ giúp cải
thiện môi trường sống.
4.42 0.59
Bảng 5.3: Đánh giá hiệu quả giáo dục của bài giảng thực tế ảo Neo Terra về phân loại rác
và bảo vệ môi trường
Sau khi có các kết quả thực nghiệm, việc phân tích hệ số Cronbach’s alpha để
xem xét sự nhất quán cũng như độ tin cậy của kết quả khảo sát là cần thiết. Cụ
thể, hệ số Cronbach’s alpha cho kết quả khảo sát thực hành bài giảng thực tế ảo
Network Lab và Neo Terra lần lượt là 0.96 và 0.94, cho thấy độ tin cậy cao của
thang đo Likert được sử dụng trong khảo sát. Điều này củng cố thêm kết quả tích
cực về hiệu quả của bài giảng thực tế ảo trong việc nâng cao kiến thức và kỹ năng
của người học.
5.4 Thảo luận
Đồ án này đã đưa ra các góc nhìn về ảnh hưởng của công nghệ thực tế ảo đối
với quá trình giảng dạy và học tập thực hành. Phân tích dữ liệu thu thập được từ
bài giảng Network Lab và Neo Terra cho thấy rằng, VR không chỉ cải thiện đáng
kể khả năng nắm bắt kiến thức và kỹ năng thực hành của người học mà còn tăng
cường nhận thức về các vấn đề môi trường.
Cụ thể, kết quả khảo sát cho thấy người học đánh giá cao tính thực tế của môi
trường VR, sự hấp dẫn của các bài giảng cũng như sự hiệu quả trong việc giúp họ
nắm bắt kiến thức. Thông qua phỏng vấn, người dùng kỳ vọng ứng dụng có thể
giảm thiểu tình trạng giật lag, tăng chất lượng đồ họa, bổ sung thêm các bài giảng
đa dạng và phong phú để tăng thêm tính thực tế và sự hứng thú cho người học. Bên
cạnh đó, việc tạo ra một môi trường học tập cho phép tương tác giữa các học viên
và giữa học viên với giảng viên cũng là một mong muốn của người dùng.
Tuy nhiên, đồ án cũng nhấn mạnh đến một số hạn chế của việc sử dụng VR trong
giáo dục. Đầu tiên là việc thiếu phản hồi xúc giác trong quá trình thực hành lắp đặt
cáp mạng trong Network Lab có thể làm giảm tính chân thực của trải nghiệm. Thứ
hai là việc áp dụng công nghệ VR trong giáo dục đòi hỏi đầu tư về cơ sở hạ tầng
và thiết bị, có thể là một rào cản đối với việc triển khai rộng rãi. Cuối cùng là việc
80
CHƯƠNG 5. ĐÁNH GIÁ THỰC NGHIỆM
cần có thêm các nghiên cứu để đánh giá tác động lâu dài của VR đến việc học tập
và hành vi của người học.
Để khắc phục những hạn chế này và tối ưu hóa trải nghiệm học tập, đồ án đề
xuất một số cải tiến cụ thể. Việc tích hợp thiết bị phản hồi xúc giác vào bài giảng
Network Lab có thể mô phỏng chính xác hơn cảm giác thực tế khi lắp đặt cáp mạng,
từ đó nâng cao tính chân thực của trải nghiệm VR. Ngoài ra, việc đa dạng hóa nội
dung bài giảng và tối ưu hóa giao diện người dùng sẽ giúp mở rộng phạm vi ứng
dụng của VR trong giáo dục và cải thiện hiệu suất, mang lại trải nghiệm mượt mà
và thoải mái hơn cho người dùng.
Bên cạnh đó, đồ án cũng đề cập đến việc cá nhân hóa trải nghiệm học tập thông
qua việc cho phép người học tùy chỉnh nội dung và tốc độ học tập theo nhu cầu cá
nhân. Điều này không chỉ giúp tăng cường sự tham gia và tương tác của người học
mà còn nâng cao hiệu quả giảng dạy. Hơn nữa, việc giảm thiểu chi phí bằng cách
tìm kiếm giải pháp công nghệ và thiết bị VR giá rẻ hơn sẽ làm tăng khả năng tiếp
cận của công nghệ này cho nhiều cơ sở giáo dục và người học.
5.5 Kết luận về khảo sát
Kết quả từ việc triển khai và khảo sát trong đồ án này đã khẳng định tính hiệu
quả của việc áp dụng công nghệ thực tế ảo vào giảng dạy thực hành, qua hệ thống
The VR Labs. Đặc biệt, bài giảng Network Lab trong môi trường VR đã cho thấy
sự cải thiện đáng kể về mức độ tự tin và thành thạo của học viên trong việc lắp đặt
cáp mạng, so với những học viên chỉ tiếp cận với phương pháp giảng dạy truyền
thống. Người học đánh giá cao tính tương tác, tính thực tế và khả năng phản hồi
tức thì của VR, giúp họ học tập một cách hiệu quả và thú vị hơn. Bên cạnh đó, bài
giảng Neo Terra đã nâng cao nhận thức của người học về tầm quan trọng của việc
phân loại rác và bảo vệ môi trường. Người học thể hiện sự hiểu biết sâu sắc và có
động lực thực hiện các hành động bảo vệ môi trường trong cuộc sống hàng ngày.
Tuy nhiên, dù đã đạt được những kết quả tích cực, vẫn còn một số hạn chế cần được
giải quyết trong tương lai để tối ưu hóa việc ứng dụng công nghệ VR trong giáo
dục.
81
CHƯƠNG 6. KẾT LUẬN
6.1 Kết luận
Đồ án này đã giải quyết vấn đề thiếu trải nghiệm thực hành và thiếu động lực
học tập trong giáo dục trực tuyến, đặc biệt thức đẩy khả năng tự học của người học,
bằng cách phát triển hệ thống bài giảng thực tế ảo The VR Labs. Hệ thống này bao
gồm hai bài giảng chính: Network Lab, tập trung vào việc giảng dạy kỹ năng lắp
đặt cáp mạng Ethernet, và Neo Terra, một bài giảng nâng cao nhận thức về phát
triển bền vững thông qua trò chơi hóa.
Kết quả đánh giá thực nghiệm cho thấy The VR Labs đã thành công trong việc
tăng cường sự tương tác và động lực học tập của người học, đồng thời cải thiện
đáng kể kiến thức và kỹ năng thực hành của họ. Cụ thể, người học đánh giá cao
tính chân thực của môi trường VR và sự hấp dẫn của các bài giảng. Tuy nhiên,
kết quả phỏng vấn cũng chỉ ra rằng các bài giảng chưa đạt được độ chân thực như
mong đợi và cần phát triển thêm các tương tác thực hành để nâng cao trải nghiệm
người dùng.
Mặc dù đồ án đã thu thập dữ liệu từ 48 người tham gia với đa dạng độ tuổi và
nền tảng kiến thức, đây vẫn là một con số khá nhỏ so với quy mô nghiên cứu. Do
đó, cần mở rộng khảo sát với số lượng người tham gia lớn hơn để có kết quả đánh
giá chính xác và khách quan hơn về tính hiệu quả của The VR Labs.
Trong tương lai, việc phát triển The VR Labs thành một nền tảng giáo dục VR
toàn diện, tích hợp với các hệ thống học tập trực tuyến hiện có như nền tảng MOOC,
là một hướng đi đầy tiềm năng. Đồng thời, việc mở rộng các bài giảng thực hành
trong The VR Labs sang các lĩnh vực khác cũng sẽ góp phần đa dạng hóa nội dung
và mở rộng phạm vi ứng dụng của công nghệ VR trong giáo dục.
6.2 Hướng phát triển trong tương lai
Đồ án này đã mang đến góc nhìn về từ phương diện lý thuyết đến ứng dụng,
thể hiện tiềm năng to lớn của công nghệ thực tế ảo trong việc nâng cao chất lượng
giảng dạy và học tập thực hành. Trong tương lai, The VR Labs có thể phát triển
thêm, trở thành một nền tảng giáo dục thực tế ảo toàn diện hơn cho người tạo nội
dung và người học, có thể tích hợp với các hệ thống học tập trực tuyến hiện có như
nền tảng MOOC của trường học như hệ thống daotao.ai.
Hình 6.1 mô tả một hệ thống giáo dục có thể phát triển từ The VR Labs. Hệ
thống này sẽ đóng vai trò như một nền tảng phát triển ứng dụng giáo dục VR, cho
phép người thiết kế dễ dàng tạo ra các bài giảng VR tương tác với sự hỗ trợ của các
82
CHƯƠNG 6. KẾT LUẬN
công cụ phát triển tích hợp. Người học sẽ được trải nghiệm môi trường học tập VR
phong phú với video, hình ảnh, ký tự và vật thể tương tác, từ đó nâng cao hiệu quả
học tập. Dữ liệu khóa học sẽ được lưu trữ và quản lý trên hệ thống MOOC, đảm
bảo tính khả chuyển và khả năng mở rộng của hệ thống.
Về mặt kiến trúc, hệ thống đề xuất bao gồm hai thành phần chính: server-side
và môi trường thực tế ảo. Phần server-side xử lý các yêu cầu từ người dùng, cung
cấp dữ liệu và nội dung khóa học thông qua các máy chủ web, máy chủ cơ sở dữ
liệu và hệ thống đám mây. Môi trường thực tế ảo, được xây dựng từ các module VR
do nhóm nghiên cứu phát triển, cung cấp một không gian học tập 3D tương tác,
nơi học viên có thể thực hành và tương tác với các đối tượng giả lập. Hệ thống này
không chỉ hỗ trợ tương tác giữa giảng viên và học viên mà còn cung cấp các công
cụ để giảng viên tạo ra các mô hình giả lập cho các khóa học trực tuyến, đồng thời
hỗ trợ việc đánh giá và phản hồi kết quả học tập của học viên trong môi trường VR.
Hình 6.1: Đề xuất phát triển hệ thống giáo dục thực tế ảo trong tương lai dài hạn
Bên cạnh đó, việc tích hợp các công nghệ tiên tiến như trí tuệ nhân tạo và học
máy vào hệ thống sẽ cho phép cá nhân hóa trải nghiệm học tập, điều chỉnh nội
dung và phương pháp giảng dạy phù hợp với từng người học, từ đó tối ưu hóa hiệu
quả giảng dạy và học tập.
Tuy nhiên, để đạt được những mục tiêu này, cần phải vượt qua một số thách
83
CHƯƠNG 6. KẾT LUẬN
thức. Việc phát triển các module VR chất lượng cao, tích hợp các công nghệ tiên
tiến và đảm bảo khả năng tương thích với các hệ thống MOOC hiện có đòi hỏi sự
đầu tư về thời gian, công sức và nguồn lực. Ngoài ra, việc giảm thiểu chi phí để
tăng khả năng tiếp cận cho các cơ sở giáo dục và người học cũng là một vấn đề cần
được quan tâm.
Mặc dù vậy, với những tiềm năng to lớn của công nghệ VR trong giáo dục, việc
phát triển The VR Labs thành một nền tảng giáo dục toàn diện là một hướng đi đầy
hứa hẹn, mở ra những cơ hội mới cho việc học tập và giảng dạy trong tương lai.
84
TÀI LIỆU THAM KHẢO
[1] S. R. Department, Size of the global e-learning market in 2019 and 2026, by

```
segment (in billion u.s. dollars), Infographic, Global e-learning market size
```

by segment 2019 with a forecast for 2026, Jul. 6, 2022. Truy cập tại: https:
//www.statista.com/statistics/1130331/e- learning-
market-size-segment-worldwide/.
[2] M. D. B. Castro và G. M. Tumibay, “A literature review: Efficacy of on-
line learning courses for higher education institution using meta-analysis,”
Education and Information Technologies, quyển 26, trang 1367–1385, 2019.

```
DOI: 10.1007/s10639-019-10027-z.
```

[3] L. Tsarova, I. Kovalova, và N. Martynenko, “Self-study work in online mode
as an innovative foreign language learning technology,” Scientific Bulletin of
Flight Academy. Section: Pedagogical Sciences, 2022. DOI: 10.33251/
2522-1477-2022-12-158-164.
[4] M. F. Sedon, C. Z. Zulkifli, M. Khairani, A. B. Sabran, và A. A. Zalay,
“Covid-19: Disadvantages of online learning towards visual arts practiced-

```
based nature,” IJEBD (International Journal of Entrepreneurship and Busi-
```

```
ness Development), 2021. DOI: 10.29138/ijebd.v4i1.1123.
```

[5] Statista, Online learning problems faced by children during the covid-19
pandemic in vietnam as of april 2020, https://www.statista.com/
statistics/1190894/vietnam-online-learning-problems-
for-children-during-covid-19-pandemic/, Truy cập ngày 20
tháng 6 năm 2024, 2020.
[6] A. V. Lê, T. T. H. Đặng, T. D. Bùi, Q. A. Vương, T. T. Phùng, và Đ. L. Đỗ,
“Thực trạng học tập trực tuyến của học sinh phổ thông việt nam trong bối
cảnh COVID-19,” Tạp chí Khoa học Giáo dục Việt Nam, quyển 18, số 03,
trang 1–10, 2022. DOI: 10.15625/2615-8957/12210301.
[7] T. H. Nguyễn, T. T. Nguyễn, và T. T. Nguyễn, “Ứng dụng công nghệ thực
tế ảo trong hoạt động dạy học,” Tạp chí Khoa học và Công nghệ, quyển 65,
số 7, trang 6573–6578, 2023.
[8] VR360, “Tổng hợp thông tin báo cáo vr trong giáo dục mới nhất,” VR360
Giải pháp Thực tế ảo VR, AR, 3D, 360, Map3D,, trang 1–17,
[9] V. E. W. Paper, Vietnam’s EdTech White Paper, Copyrighted material Con-
ducted by EdTech Agency, Aug. 2023.
[10] “Các xu thế ứng dụng công nghệ ’ảo’ trong giáo dục,” Tạp chí Giáo dục
Việt Nam, 2023. Truy cập tại: https://tapchigiaoduc.edu.vn/
85
TÀI LIỆU THAM KHẢO
article/87160/225/cac- xu- the- ung- dung- cong- nghe-
ao-trong-giao-duc/.
[11] K.-C. Hu, D. Salcedo, Y.-N. Kang, và cộng sự, “Impact of virtual reality
anatomy training on ultrasound competency development: A randomized
controlled trial,” PLoS ONE, quyển 15, 2020. DOI: 10.1371/journal.
pone.0242731.
[12] E.-A. Kim và K.-J. Cho, “Comparing the effectiveness of two new cpr train-
ing methods in korea: Medical virtual reality simulation and flipped learn-
ing,” Iranian Journal of Public Health, quyển 52, trang 1428–1438, 2023.

```
DOI: 10.18502/ijph.v52i7.13244.
```

[13] G. M. Enda McGovern và C. Luna-Nevarez, “An application of virtual re-
ality in education: Can this technology enhance the quality of students’ learn-
ing experience?” Journal of Education for Business, quyển 95, số 7, trang 490–
496, 2020. DOI: 10.1080/08832323.2019.1703096. eprint: https:
//doi.org/10.1080/08832323.2019.1703096. Truy cập tại:

```
https://doi.org/10.1080/08832323.2019.1703096.
```

[14] S. Nikolic, D. Stirling, và M. Ros, “Formative assessment to develop oral
communication competency using youtube: Self- and peer assessment in en-
gineering,” European Journal of Engineering Education, quyển 43, trang 1–
14, Mar. 2017. DOI: 10.1080/03043797.2017.1298569.
[15] T. M. Uoc, “Digital transformation in higher education in vietnam today,”

```
Revista de Gestão e Secretariado (Management and Administrative Profes-
```

```
sional Review), 2023. DOI: 10.7769/gesec.v14i8.2699.
```

[16] United Nations, Objectifs de développement durable, French, https://
www.un.org/sustainabledevelopment/fr/objectifs-de-
developpement-durable/, Truy cập ngày 22 tháng 6 năm 2024, 2015.
[17] Organisation internationale de la Francophonie, Hackathon « jeu parle franc¸ais
» : Dix équipes sélectionnées pour la finale à bucarest ! French, https:
//parlonsfrancais.francophonie.org/hackathon- jeu-
parle- francais- dix- equipes- selectionnees- pour- la-
finale-a-bucarest/, Truy cập ngày 22 tháng 6 năm 2024, 2024.
[18] N. V. Hạnh, Lý luận và phương pháp dạy học, Giáo dục trải nghiệm – Một
nền tảng giáo dục trong thế kỉ 21. Hà Nội: Trường Đại học Bách Khoa Hà
Nội, Viện Sư phạm Kỹ thuật, 2020.
[19] R. Phillips, “Challenging the primacy of lectures:the dissonance between
theory and practice in university teaching,” Journal of University Teaching
Learning Practice, quyển 2, Jan. 2005. DOI: 10.53761/1.2.1.2.
86
TÀI LIỆU THAM KHẢO
[20] World Economic Forum, Schools of the future: Defining new models of ed-
ucation for the fourth industrial revolution, 2020. Truy cập tại: https :
/ / www. weforum . org / publications / schools - of - the -
future - defining - new - models - of - education - for- the-
fourth-industrial-revolution/.
[21] G. P. Papanastasiou, A. Drigas, C. Skianis, M. D. Lytras, và E. Papanastasiou,
“Virtual and augmented reality effects on k-12, higher and tertiary education
students’ twenty-first century skills,” Virtual Reality, quyển 23, trang 425–
436, 2018. DOI: 10.1007/s10055-018-0363-2.
[22] N. Pellas, A. Dengel, và A. Christopoulos, “A scoping review of immer-
sive virtual reality in stem education,” IEEE Transactions on Learning Tech-
nologies, quyển 13, trang 748–761, 2020. DOI: 10 . 1109 / TLT. 2020 . 3019405.
[23] U. A. Chattha, U. Janjua, F. Anwar, T. M. Madni, M. F. Cheema, và S. I.
Janjua, “Motion sickness in virtual reality: An empirical evaluation,” IEEE
Access, quyển 8, trang 130 486–130 499, 2020. DOI: 10.1109/ACCESS.
2020.3007076.
[24] P. Caserman, A. Garcia-Agundez, A. G. Zerban, và S. G¨obel, “Cybersick-
ness in current-generation virtual reality head-mounted displays: Systematic
review and outlook,” Virtual Reality, quyển 25, trang 1153–1170, 2021. DOI:
10.1007/s10055-021-00513-6.
[25] T. Alsop, Volume of vr headsets worldwide 2018-2028, https://www.
statista . com / forecasts / 1331896 / vr- headset - sales -
volume-worldwide, Truy cập ngày 22 tháng 6 năm 2024, 2024.
[26] R. C. Richey, “Reflections on the 2008 aect definitions of the field,” TechTrends,
quyển 52, số 1, trang 24–25, 2008, ISSN: 8756-3894. DOI: 10 . 1007 /
s11528-008-0108-2.
[27] M. Weller, “25 years of ed tech,” 2020. DOI: 10 . 15215 / aupress /
9781771993050.01.
[28] L. Jarmon, T. Traphagan, M. Mayrath, và A. Trivedi, Virtual world teaching,
experiential learning, and assessment: An interdisciplinary communication
course in Second Life. Elsevier, 2009, quyển 53, trang 169–182.
[29] M. Ulum và A. Fauzi, “Behaviorism theory and its implications for learn-
ing,” Journal of Insan Mulia Education, 2023. DOI: 10.59923/joinme.
v1i2.41.
87
TÀI LIỆU THAM KHẢO
[30] Y. Lu và Y. A. Hamu, “Teori operant conditioning menurut burrhusm fred-
eric skinner,” Jurnal Arrabona, quyển 5, số 1, Article 1, 2022. DOI: https:
//doi.org/10.57058/juar.v5i1.65.
[31] W. Mursyidi, “Kajian teori belajar behaviorisme dan desain instruksional,” 2020. DOI: https://doi.org/10.38153/almarhalah.v3i1. 30.
[32] G. Akhundova, “The transition from cognitivism to constructivism in foreign
language teaching: Comparative analysis,” quyển 1, trang 177–181, 2020.

```
DOI: 10.24919/2308-4863/34-1-28.
```

[33] J. Mattar, “Constructivism and connectivism in education technology: Ac-
tive, situated, authentic, experiential, and anchored learning,” RIED: Revista
Iberoamericana de Educación a Distancia, quyển 21, trang 201–217, 2018.

```
DOI: 10.5944/RIED.21.2.20055.
```

[34] J. R. Utecht và D. M. Keller, “Becoming relevant again: Applying connec-
tivism learning theory to today’s classrooms.,” Critical Questions in Educa-
tion, quyển 10, trang 107–119, 2019.
[35] A. Y. Kolb và D. Kolb, “Experiential learning theory as a guide for experi-
ential educators in higher education,” Experiential Learning and Teaching in
Higher Education, 2022. DOI: 10.46787/elthe.v1i1.3362.
[36] H. P. Young, “Learning by trial and error,” Games and Economic Behav-
ior, quyển 65, số 2, trang 626–643, 2009, ISSN: 0899-8256. DOI: https:
/ / doi . org / 10 . 1016 / j . geb . 2008 . 02 . 011. Truy cập tại:

```
https://www.sciencedirect.com/science/article/pii/
```

S0899825608000614.
[37] N. R. Salikhova, M. F. Lynch, và A. Salikhova, “Psychological aspects of dig-
ital learning: A self-determination theory perspective,” Contemporary Edu-
cational Technology, 2020. DOI: 10.30935/cedtech/8584.
[38] D. D. Gallo, “Expectancy theory as a predictor of individual response to
computer technology,” Computers in Human Behavior, quyển 2, trang 31–

```
41, 1986. DOI: 10.1016/0747-5632(86)90020-8.
```

[39] P. Buckley và E. Doyle, “Gamification and student motivation,” Interactive
Learning Environments, quyển 24, trang 1162–1175, 2016. DOI: 10.1080/
10494820.2014.964263.
[40] M. Sailer và L. Homner, “The gamification of learning: A meta-analysis,”
Educational Psychology Review, quyển 32, trang 77–112, 2019. DOI: 10.
1007/S10648-019-09498-W.
88
TÀI LIỆU THAM KHẢO
[41] J. R. Hill, L. Song, và R. West, “Social learning theory and web-based learn-
ing environments: A review of research and discussion of implications,”
American Journal of Distance Education, quyển 23, trang 103–88, 2009.

```
DOI: 10.1080/08923640902857713.
```

[42] R. Duran, A. Zavgorodniaia, và J. Sorva, “Cognitive load theory in comput-
ing education research: A review,” ACM Transactions on Computing Educa-

```
tion (TOCE), quyển 22, trang 1–27, 2022. DOI: 10.1145/3483843.
```

[43] K. Inna, T. Liudmyla, V. Iryna, và M. Nataliia, “Implementing the theory
of multiple intelligences into project-based multimedia learning at primary
school,” Information Technologies and Learning Tools, quyển 82, trang 18–
31, 2021. DOI: 10.33407/ITLT.V82I2.4326.
[44] M. Kapur, “Productive failure in learning math,” Cognitive Science, quyển 38,
số 6, trang 1008–1022, 2014.
[45] A. Cisneros, M. Maravilla, B. Murray, D. Scretching, A. Stoddard, và E. M.
Redmiles, “Defining virtual reality: Insights from research and practice,” in
iConference 2019 Proceedings, 2019. Truy cập tại: https://doi.org/
10.21900/iconf.2019.103338.
[46] D. Freeman, S. Reeve, A. Robinson, và cộng sự, “Virtual reality in the as-
sessment, understanding, and treatment of mental health disorders,” Psycho-
logical Medicine, quyển 47, số 14, trang 2393–2400, 2017. DOI: 10.1017/
S003329171700040X.
[47] C. Cruz-Neira, D. J. Sandin, và T. A. DeFanti, “Surround-screen projection-
based virtual reality: The design and implementation of the CAVE,” in ACM

```
Computer Graphics (SIGGRAPH) Proceedings, quyển 27, 1993, trang 135–
```

142. [48] M. Slater, B. Spanlang, M. Sanchez-Vives, và O. Blanke, “First person expe-
     rience of body transfer in virtual reality,” PLOS ONE, quyển 5, số 4, e10564,
143. DOI: 10.1371/journal.pone.0010564.
     [49] B. Spanlang, J.-M. Normand, D. Borland, và cộng sự, “How to build an
     embodiment lab: Achieving body representation illusions in virtual reality,”
     Frontiers in Robotics and AI, quyển 1, 2014. DOI: 10 . 3389 / frobt .
     2014.00009.
     [50] M. Ferrer-Garcia, J. Gutierrez-Maldonado, J. Treasure, và F. Vilalta-Abella,
     “Craving for food in virtual reality scenarios in a non-clinical sample: Anal-
     ysis of its relationship with body mass index and eating disorder symptoms,”
     European Eating Disorders Review, quyển 23, số 5, trang 371–378, 2015,

```
ISSN: 1660-283X. DOI: 10.1002/erv.2374.
```

89
TÀI LIỆU THAM KHẢO
[51] W. Luo, “The benefit of a regression in vr game,” in Highlights in Science,
Engineering and Technology CMLAI 2023, quyển 39, 2023, trang 376–382.
[52] R. P. McMahan, D. A. Bowman, D. J. Zielinski, và R. B. Brady, “Evaluating
display fidelity and interaction fidelity in a virtual reality game,” in 2012

```
IEEE Virtual Reality (VR), IEEE, 2012, trang 15–22.
```

[53] Y. Liu, “Analysis of interaction methods in vr virtual reality,” Highlights
in Science, Engineering and Technology, 2023. DOI: 10.54097/hset.
v39i.6559.

```
[54] K. Mills và A. Brown, “Immersive virtual reality (vr) for digital media mak-
```

```
ing: Transmediation is key,” Learning, Media and Technology, quyển 47,
```

trang 179–200, 2021. DOI: 10.1080/17439884.2021.1952428.
[55] D. A. Bowman và R. P. McMahan, “Virtual reality: How much immersion
is enough?” Computer, quyển 40, số 7, trang 36–43, Jul. 2007, ISSN: 0018- 9162. DOI: 10.1109/MC.2007.263.
[56] R. J. Teather, W. Stuerzlinger, và J. Shephard, “The effect of frame rate on
simulator sickness for a first-person perspective task,” Displays, quyển 44,
trang 1–8, Aug. 2016. DOI: 10.1016/j.displa.2016.05.001. Truy
cập tại: https://doi.org/10.1016/j.displa.2016.05.001.
[57] M. Slater, A. Antley, A. Davison, và cộng sự, “A virtual reprise of the stanley
milgram obedience experiments,” PLoS ONE, quyển 1, số 1, e39, Aug. 2006.

```
DOI: 10 . 1371 / journal . pone . 0003939. Truy cập tại: https :
```

//doi.org/10.1371/journal.pone.0003939.
[58] Pico, Pico 4 - thiết bị thực tế ảo, https://www.picoxr.com/, Truy
cập ngày 28/06/2024, 2024.
[59] Meta, Meta quest 2 - virtual reality headset, https://www.meta.com/
quest/products/quest-2/, Truy cập ngày 28/06/2024, 2024.
[60] E. C. BKVerse Team, Kho lưu trữ module của bkverse team: Bkverse-module,

```
https://github.com/bkverse-team/bkverse-module, 2023.
```

[61] EdTech Centre - daotao.ai, Hướng nghiệp 4.0 ngành công nghệ thông tin,

```
https://www.facebook.com/edtechcentredaotaoai/videos/
```

1934648476898080, [Truy cập ngày 29 tháng 6, 2024], 2023.
90
PHỤ LỤC
91
A. LỊCH SỬ PHÁT TRIỂN CỦA CÔNG NGHỆ GIÁO DỤC
Bảng A.1 trình bày các mốc thời gian quan trọng trong sự phát triển của công

```
nghệ giáo dục từ năm 1994 đến năm 2018, dựa trên nghiên cứu của Weller (2020)
```

[27].
Năm Sự kiện chính Mô tả ngắn gọn
1994 Hệ thống bảng tin

```
(BBS)
```

Tiền thân của các nền tảng mạng xã hội và diễn đàn
trực tuyến ngày nay, cho phép người dùng kết nối, chia
sẻ nội dung và trao đổi thông tin.
1995 Web Sự ra đời của web đã tạo ra một cuộc cách mạng trong
giáo dục, cung cấp một nền tảng rộng lớn để xuất bản,
giao tiếp và chia sẻ thông tin, tạo điều kiện cho việc học
tập từ xa và mở rộng khả năng tiếp cận giáo dục.
1996 Giao tiếp qua máy

```
tính (CMC)
```

CMC bao gồm nhiều hình thức giao tiếp kỹ thuật số
khác nhau như nhắn tin tức thời, email, diễn đàn thảo
luận và trò chơi trực tuyến, tạo ra nhiều cơ hội mới cho
việc học tập và hợp tác trực tuyến.
1997 Chủ nghĩa kiến tạo Chủ nghĩa kiến tạo, một lý thuyết học tập quan trọng,
nhấn mạnh vai trò chủ động của người học trong việc
xây dựng kiến thức thông qua trải nghiệm và tương tác
xã hội. Lý thuyết này đã thách thức các mô hình giáo
dục truyền thống và đặt nền móng cho các phương pháp
tiếp cận học tập lấy người học làm trung tâm.
1998 Wiki Wiki, các trang web mà người dùng có thể cùng nhau
chỉnh sửa nội dung, đã thúc đẩy tinh thần hợp tác và chia
sẻ kiến thức trong cộng đồng trực tuyến. Wikipedia là
một ví dụ điển hình về sức mạnh của mô hình này trong
việc xây dựng một nguồn tài nguyên thông tin mở và
toàn diện.

```
1999 Học trực tuyến (E-
```

```
learning)
```

E-learning đã trở thành một phần không thể thiếu của
giáo dục hiện đại, tích hợp các yếu tố của web, CMC,
chủ nghĩa kiến tạo và các công cụ như wiki để cung cấp
các chương trình học tập linh hoạt và phù hợp với nhu
cầu của người học.
92
CHƯƠNG A. LỊCH SỬ PHÁT TRIỂN CỦA CÔNG NGHỆ GIÁO DỤC
Năm Sự kiện chính Mô tả ngắn gọn
2000 Đối tượng học tập

```
(LO)
```

```
Khái niệm đối tượng học tập (LO) được đưa ra với mục
```

tiêu áp dụng tính linh hoạt và khả năng tái sử dụng của
lập trình hướng đối tượng vào lĩnh vực giáo dục. Mặc dù
chưa đạt được thành công như mong đợi, LO đã đặt nền
tảng cho sự phát triển của các tiêu chuẩn học trực tuyến

```
và các khái niệm như tài nguyên giáo dục mở (OER).
```

2001 Tiêu chuẩn học trực
tuyến
Sự ra đời của các tiêu chuẩn học trực tuyến như IMS và
SCORM đã giải quyết các vấn đề về khả năng tương tác
và tái sử dụng nội dung giữa các nền tảng khác nhau.
Bên cạnh đó, Dublin Core, một bộ siêu dữ liệu, đã được
giới thiệu để mô tả các tài nguyên kỹ thuật số, mặc dù
việc tạo ra siêu dữ liệu này thường đòi hỏi nhiều công
sức.
2002 Hệ thống quản lý học

```
tập (LMS)
```

```
LMS, còn được gọi là Môi trường học tập ảo (VLE),
```

đã trở thành một giải pháp tập trung cho việc học trực
tuyến, tích hợp nhiều công cụ khác nhau như diễn đàn
thảo luận, hệ thống quản lý nội dung và các trang web
để hỗ trợ quá trình dạy và học trực tuyến một cách hiệu
quả.
2003 Blog Blog đã trở thành một công cụ phổ biến trong giáo dục,
cho phép các học giả, nhà giáo dục và người học chia sẻ
ý tưởng, phản ánh kinh nghiệm và xây dựng cộng đồng
học tập. Blog cũng tạo ra một hình thức nhận dạng học
thuật mới, thúc đẩy các cuộc thảo luận và hợp tác giữa
các ngành.
2004 Tài nguyên giáo dục

```
mở (OER)
```

Phong trào OER nổi lên với mục tiêu cung cấp tài
nguyên giáo dục được cấp phép mở, cho phép truy cập
và điều chỉnh miễn phí. Sáng kiến OpenCourseWare
của MIT đã đi đầu trong việc chia sẻ nội dung giáo
dục một cách cởi mở, tạo ra một nguồn tài nguyên học
tập phong phú và đa dạng cho cộng đồng.
93
CHƯƠNG A. LỊCH SỬ PHÁT TRIỂN CỦA CÔNG NGHỆ GIÁO DỤC
Năm Sự kiện chính Mô tả ngắn gọn

```
2005 Video (YouTube) Sự ra đời của YouTube và các nền tảng chia sẻ video
```

khác đã tạo ra một cuộc cách mạng trong giáo dục, cho
phép người dùng dễ dàng tạo và chia sẻ nội dung video.
Điều này đã làm dân chủ hóa việc sản xuất nội dung và
thúc đẩy sự phát triển của các nền văn hóa tham gia, nơi
người học có thể tự tạo và chia sẻ nội dung học tập của
riêng mình.
2006 Web 2.0 Web 2.0 đánh dấu sự chuyển đổi sang nội dung do người
dùng tạo và các dịch vụ tương tác trên web. Các công

```
cụ như folksonomies (thẻ do người dùng tạo), đánh dấu
```

trang xã hội và mã nhúng đã tạo điều kiện thuận lợi cho
việc cộng tác và chia sẻ trong giáo dục, giúp người học
dễ dàng truy cập và tương tác với nội dung học tập hơn.

```
2007 Thế giới ảo (Second
```

```
Life)
```

Thế giới ảo như Second Life đã được khám phá như
một môi trường tiềm năng cho giáo dục, cho phép tạo
ra các bài giảng ảo, khuôn viên ảo và các hoạt động
học tập nhập vai. Tuy nhiên, việc áp dụng rộng rãi công
nghệ này đã gặp phải nhiều thách thức về công nghệ,
khả năng tiếp cận và tính thực tế.
2008 E-portfolios E-portfolios là một công cụ kỹ thuật số cho phép người
học thu thập, lưu trữ và trình bày các sản phẩm học tập,
đánh giá và tài nguyên của mình. Chúng hỗ trợ việc tự
đánh giá, phản ánh và lập kế hoạch phát triển cá nhân,
đồng thời cho phép người học chia sẻ và giới thiệu thành
tích học tập của mình với người khác.
2009 Twitter và phương
tiện truyền thông xã
hội
Sự phát triển của Twitter và các nền tảng mạng xã hội
khác đã cách mạng hóa cách thức giao tiếp và tương
tác trong giáo dục. Chúng cho phép các cuộc thảo luận
toàn cầu, hợp tác xuyên ngành và xây dựng mạng lưới
học thuật, đồng thời làm mờ ranh giới giữa học thuật và
cuộc sống cá nhân.
94
CHƯƠNG A. LỊCH SỬ PHÁT TRIỂN CỦA CÔNG NGHỆ GIÁO DỤC
Năm Sự kiện chính Mô tả ngắn gọn
2010 Chủ nghĩa kết nối Chủ nghĩa kết nối là một lý thuyết học tập mới tập trung
vào việc học tập trong môi trường mạng, nhấn mạnh
tầm quan trọng của việc kết nối, chia sẻ và tương tác
trong quá trình học tập. Lý thuyết này xem kiến thức là
phân tán và quá trình học tập là một quá trình liên tục,
không ngừng phát triển thông qua việc kết nối với các
nút thông tin và cá nhân khác nhau.
2011 Môi trường học tập

```
cá nhân (PLE)
```

PLE là một tập hợp các công cụ, cộng đồng và dịch vụ
mà người học sử dụng để tự định hướng việc học của
mình. PLE trao quyền kiểm soát và cá nhân hóa cho
người học, cho phép họ lựa chọn và kết hợp các công
cụ khác nhau để đáp ứng nhu cầu và mục tiêu học tập
của mình.
2012 Các khóa học trực
tuyến mở quy mô lớn

```
(MOOC)
```

MOOC là các khóa học trực tuyến miễn phí, có thể
mở rộng cho một lượng lớn người học trên toàn cầu.
Sự ra đời của MOOC đã tạo ra một cuộc cách mạng
trong giáo dục, mở rộng khả năng tiếp cận giáo dục
đại học và tạo ra nhiều cơ hội học tập mới cho mọi
người. Tuy nhiên, MOOC cũng đặt ra nhiều thách thức
về chất lượng, tỷ lệ hoàn thành và mô hình kinh doanh
bền vững.
2013 Sách giáo khoa mở

```
(Open Textbooks)
```

```
Sách giáo khoa mở (Open Textbooks) là phiên bản kỹ
```

thuật số có thể truy cập miễn phí và phiên bản in giá rẻ
của sách giáo khoa truyền thống. Chúng nhằm mục đích
giảm chi phí cho sinh viên và tăng khả năng tiếp cận
tài liệu học tập. Các dự án như OpenStax, Open Text-
book Library, BCcampus và Lumen Learning đều đang
phát triển hoặc quảng bá sách giáo khoa mở. Nghiên
cứu đã chỉ ra rằng sách giáo khoa mở có chất lượng
tương đương hoặc thậm chí tốt hơn so với sách giáo
khoa truyền thống.
95
CHƯƠNG A. LỊCH SỬ PHÁT TRIỂN CỦA CÔNG NGHỆ GIÁO DỤC
Năm Sự kiện chính Mô tả ngắn gọn

```
2014 Phân tích học tập Phân tích học tập (Learning Analytics) sử dụng dữ liệu
```

để hiểu và cải thiện việc học tập của học sinh. Nó liên
quan đến việc thu thập, phân tích và báo cáo dữ liệu về
tiến độ, mức độ tương tác và hành vi của người học để
đưa ra các quyết định sáng suốt về hướng dẫn và hỗ trợ.
Phân tích học tập có thể được sử dụng để xác định các
vấn đề và thực hiện các biện pháp can thiệp hiệu quả,
cũng như phân tích dài hạn để hiểu rõ hơn về hành vi
của học sinh. Tuy nhiên, việc sử dụng phân tích học tập
cũng đặt ra những câu hỏi về quyền riêng tư dữ liệu và
đạo đức.

```
2015 Huy hiệu kỹ thuật số Huy hiệu kỹ thuật số (Digital Badges) là một hình thức
```

công nhận kỹ thuật số về thành tích, kỹ năng và năng
lực của người học. Chúng cung cấp một cách linh hoạt
và cụ thể hơn để ghi lại và thể hiện thành tích học tập so
với bằng cấp truyền thống. Huy hiệu kỹ thuật số có thể
được xác minh và liên kết với bằng chứng, giúp người
học dễ dàng chia sẻ và chứng minh năng lực của mình
với nhà tuyển dụng và các tổ chức giáo dục khác.
2016 Sự trở lại của trí tuệ

```
nhân tạo (AI)
```

```
Trí tuệ nhân tạo (AI) đã trở lại mạnh mẽ trong lĩnh vực
```

công nghệ giáo dục, tập trung vào các hệ thống dạy

```
kèm thông minh (ITS) và ứng dụng của nó trong việc
```

cá nhân hóa học tập, đánh giá tự động và hỗ trợ thích
ứng. Tuy nhiên, việc sử dụng AI trong giáo dục cũng
đặt ra những lo ngại về đạo đức, quyền riêng tư dữ liệu
và tác động của nó đối với vai trò của giáo viên.
2017 Blockchain Blockchain được khám phá để ứng dụng trong việc lưu
trữ và xác minh thông tin đăng nhập giáo dục một cách
an toàn. Công nghệ này có tiềm năng tạo điều kiện cho
việc chuyển tín chỉ, công nhận việc học tập không chính
thức và trao quyền sở hữu dữ liệu cho người học. Tuy
nhiên, việc áp dụng blockchain trong giáo dục vẫn đang
trong giai đoạn thử nghiệm và cần được nghiên cứu
thêm để đánh giá hiệu quả và tính khả thi của nó.
96
CHƯƠNG A. LỊCH SỬ PHÁT TRIỂN CỦA CÔNG NGHỆ GIÁO DỤC
Năm Sự kiện chính Mô tả ngắn gọn
2018 Sự chuyển hướng
sang phản địa đàng
của EdTech
Năm 2018 đánh dấu sự chuyển hướng sang một cách
tiếp cận mang tính phê phán hơn đối với công nghệ giáo
dục. Các học giả và nhà giáo dục bắt đầu xem xét kỹ
lưỡng những tác động tiêu cực tiềm ẩn của công nghệ
đối với người học, thực hành học thuật và bối cảnh giáo
dục nói chung. Các vấn đề như quyền riêng tư dữ liệu,
đạo đức, giám sát và phân cực kỹ thuật số ngày càng
được quan tâm và thảo luận nhiều hơn.
Bảng A.1: Các cột mốc quan trọng trong quá trình phát triển của công nghệ trong giáo dục
[27]
97
B. PHIẾU KHẢO SÁT ỨNG DỤNG THE VR LABS
Phần 1: Thông tin cá nhân
STT Mục Thông tin
1.1 Họ và tên
1.2 Tuổi

```
1.3 Email (ưu tiên email
```

```
trường học)
```

1.4 Trình độ chuyên
môn
□ Sinh viên năm nhất Đại học
□ Sinh viên năm hai Đại học
□ Sinh viên năm ba Đại học
□ Sinh viên năm tư Đại học
□ Sinh viên năm năm Đại học
□ Học sinh THPT
□ Mục khác:
1.5 Tên trường Đại học

```
1.6 MSSV (nếu có)
```

Phần 2: Thông tin chung về bài giảng và sử dụng thiết bị VR
Câu hỏi 2.1: Bạn tham gia những bài giảng nào?
□ Network Lab
□ Neo Terra
Câu hỏi 2.2: Bạn đã sử dụng thiết bị VR trước đó chưa?
□ Rồi
□ Chưa
Câu hỏi 2.3: Bạn mất bao lâu để làm quen với thiết bị VR?
Phần 3: Khảo sát Network Lab
Câu hỏi 3.1: Bạn đã từng học lắp dây mạng trước đây chưa?
□ Rồi
□ Chưa
Câu hỏi 3.2: Bạn kỳ vọng gì ở bài giảng lắp dây mạng?
98
CHƯƠNG B. PHIẾU KHẢO SÁT ỨNG DỤNG THE VR LABS
HỌC THỰC HÀNH LẮP DÂY MẠNG QUA VIDEO VÀ BÀI GIẢNG 2D
Thời gian: 10 phút
Câu hỏi 3.3.1: Bạn đánh giá thế nào về bài giảng 2D?
Lưu ý: 1 - Hoàn toàn không đồng ý, 2 - Không đồng ý, 3 - Không ý kiến, 4 - Đồng
ý, 5 - Hoàn toàn đồng ý.
STT Nhận xét
Mức độ đồng ý
1 2 3 4 5
1 Tôi đã đọc tài liệu hướng dẫn và xem
video bài giảng nhiều lần.
2 Tôi ghi chép lại các bước thực hiện trong
quá trình học.
3 Tôi hiểu rõ các bước thực hiện trong quy
trình lắp đặt cáp Ethernet.
4 Tôi đã tìm hiểu thêm thông tin về lắp đặt

```
cáp Ethernet từ các nguồn khác nhau (ví
```

```
dụ: internet, sách, video)
```

5 Tôi cảm thấy có quyền tự do lựa chọn
cách học và tốc độ học phù hợp với bản
thân
6 Tôi tin rằng việc học qua nguồn tài liệu
2D sẽ giúp tôi chuẩn bị tốt hơn cho việc
thực hành lắp đặt cáp Ethernet trên thiết
bị thật.
7 Tôi không gặp khó khăn trong việc hiểu
và ghi nhớ các bước thực hiện trong bài
giảng 2D.
8 Bài giảng 2D cung cấp đủ thông tin để tôi
có thể tự thực hành lắp đặt cáp Ethernet
trên thiết bị thật.
Bảng B.1: Bảng nhận xét về bài giảng 2D
Câu hỏi 3.3.2: Thời gian hoàn thành trên thiết bị thật là
Câu hỏi 3.3.3: Các yếu tố nào khiến bạn cảm thấy hào hứng và muốn tiếp
tục học?
99
CHƯƠNG B. PHIẾU KHẢO SÁT ỨNG DỤNG THE VR LABS
HỌC QUA VR VỚI ỨNG DỤNG NETWORK LAB
Câu hỏi 3.4.1: Bạn đánh giá thế nào về bài giảng Network Lab?
Lưu ý: 1 - Hoàn toàn không đồng ý, 2 - Không đồng ý, 3 - Không ý kiến, 4 - Đồng
ý, 5 - Hoàn toàn đồng ý.
STT Nhận xét
Mức độ đồng ý
1 2 3 4 5
1 Tôi đã thực hành lắp đặt cáp Ethernet
nhiều lần trong môi trường VR.
2 Tôi hiểu rõ các bước thực hiện trong quy
trình lắp đặt cáp Ethernet.
3 Tôi có thể xác định và sửa chữa các lỗi
thường gặp trong quá trình lắp đặt cáp
Ethernet.
4 Tôi có thể áp dụng kiến thức đã học để
giải quyết các tình huống lắp đặt cáp Eth-
ernet khác nhau.
5 Tôi đã tìm kiếm thêm thông tin về lắp đặt
cáp Ethernet từ các nguồn khác nhau.
6 Tôi cảm thấy bài thực hành VR là một trải
nghiệm học tập thực tế và hữu ích.
7 Tôi cảm thấy tự tin hơn khi thực hành lắp
đặt cáp Ethernet trên thiết bị thật sau khi
trải nghiệm VR.
8 Tôi cảm thấy có quyền tự do lựa chọn
cách học và thực hành trong môi trường
VR.
9 Tôi cảm thấy bài thực hành VR giúp tôi
nâng cao năng lực lắp đặt cáp Ethernet.
10 Tôi tin rằng việc thực hành trong VR sẽ
giúp tôi tự tin hơn khi làm việc với các
thiết bị mạng thật.
11 Các yếu tố như điểm số, huy hiệu, bảng
xếp hạng giúp tôi có thêm động lực để
thực hành trong VR.
Tiếp tục trên trang sau
100
CHƯƠNG B. PHIẾU KHẢO SÁT ỨNG DỤNG THE VR LABS
Bảng B.2 – tiếp theo từ trang trước
STT Nhận xét
Mức độ đồng ý
1 2 3 4 5
12 Tôi cảm thấy tự tin hơn khi thực hiện các
thao tác lắp đặt cáp Ethernet sau khi xem
hướng dẫn và ví dụ trong VR.
13 Tôi cảm thấy lượng thông tin trong bài
thực hành VR vừa đủ, không quá nhiều
hoặc quá ít.
14 Tôi cảm thấy các thiết bị và công cụ trong
VR giống với những gì tôi sử dụng trong
thực tế.
15 Tôi cảm thấy tự tin hơn trong việc áp
dụng kiến thức vào các tình huống thực
tế sau khi thực hành trong VR.
16 Tôi cảm thấy VR tạo điều kiện cho việc
tự học và khám phá kiến thức một cách
linh hoạt.
17 Tôi cảm thấy các tương tác trong VR mô
phỏng chân thực các thao tác kỹ thuật
trong lắp đặt và cấu hình mạng.
18 Tôi cảm thấy môi trường VR cung cấp
phản hồi kịp thời và chính xác, giúp tôi
hiểu được các sai sót và cách khắc phục.
19 Tôi cảm thấy việc sử dụng VR trong học
tập tạo ra một trải nghiệm học tập thú vị
và tương tác cao.
20 Tôi thấy việc học lắp đặt cáp Ethernet
trong VR hiệu quả hơn so với việc chỉ học
lý thuyết và thực hành trên thiết bị thật.
21 Tôi thích học lắp đặt cáp Ethernet trong
VR hơn so với việc học lý thuyết và thực
hành trên thiết bị thật.
22 Bài thực hành VR có độ khó phù hợp với
trình độ của tôi.
Bảng B.2: Bảng nhận xét về bài giảng Network Lab
101
CHƯƠNG B. PHIẾU KHẢO SÁT ỨNG DỤNG THE VR LABS
Câu hỏi 3.4.2: Thời gian hoàn thành trên thiết bị thật là
Phần 4: Khảo sát Neo Terra
Câu hỏi 4.1: Bạn hãy tự đánh giá về bài giảng thực thế ảo Neo Terra sau
khi trải nghiệm.
Lưu ý: 1 - Hoàn toàn không đồng ý, 2 - Không đồng ý, 3 - Không ý kiến, 4 - Đồng
ý, 5 - Hoàn toàn đồng ý.
STT Nhận xét
Mức độ đồng ý với quan điểm
1 2 3 4 5

1. Tôi đã thực hành phân loại rác nhiều lần
   trong môi trường VR.
2. Tôi nhận được phản hồi ngay lập tức về
   việc phân loại rác đúng hay sai.
3. Việc thực hành lặp đi lặp lại trong VR
   giúp tôi phân loại rác tốt hơn.
4. Tôi hiểu rõ các loại rác và cách phân loại
   chúng sau bài giảng.
5. Tôi có thể giải thích tại sao việc phân loại
   rác lại quan trọng.
6. Tôi có thể phân biệt được sự phân loại các
   loại rác thải
7. Tôi đã chủ động tìm hiểu thêm thông tin
   về tái chế và phát triển bền vững sau bài
   giảng.
8. Tôi có thể áp dụng kiến thức đã học để
   đề xuất các giải pháp giảm thiểu rác thải
   trong cuộc sống hàng ngày.
9. Tôi đã tìm kiếm thêm thông tin về tái chế
   và phát triển bền vững từ các nguồn khác

```
nhau (ví dụ: internet, sách, báo).
```

10. Tôi sẽ chia sẻ và thảo luận với người khác
    về vấn đề tái chế và phát triển bền vững.
11. Bài giảng Neo Terra giúp tôi hiểu rõ hơn
    về tác động của rác thải đến môi trường.
12. Tôi cảm thấy có trách nhiệm hơn trong
    việc bảo vệ môi trường sau bài giảng.
    Tiếp tục trên trang sau
    102
    CHƯƠNG B. PHIẾU KHẢO SÁT ỨNG DỤNG THE VR LABS
    Bảng B.3 – tiếp theo từ trang trước
    STT Nhận xét
    Mức độ đồng ý với quan điểm
    1 2 3 4 5
13. Tôi cảm thấy bài giảng Neo Terra khơi
    dậy sự quan tâm của tôi đến vấn đề môi
    trường.
14. Tôi cảm thấy có động lực để tìm hiểu
    thêm về phát triển bền vững.
15. Tôi cảm thấy bài giảng Neo Terra cho tôi
    quyền tự do khám phá và tìm hiểu theo
    cách riêng của mình.
16. Tôi tin rằng việc phân loại rác đúng cách
    sẽ giúp cải thiện môi trường sống.
    Bảng B.3: Bảng nhận xét về bài giảng Neo Terra
    Câu hỏi 4.2: Liệt kê 3 từ vựng tiếng Pháp với nghĩa tiếng Việt bạn học được
    qua bài giảng Neo Terra:
17.
18.
19. Câu hỏi 4.3: Liệt kê 3 cách tái chế bạn học được qua bài giảng Neo Terra:
20.
21.
22. Phần 5: Đánh giá chung
    Câu hỏi 5.1: Bạn thấy học bằng phương pháp nào thú vị hơn:
    □ Học bằng các tài liệu 2D
    □ Học qua ứng dụng thực tế ảo

```
Câu hỏi 5.2: Bạn đề xuất cải thiện ứng dụng thế nào (kỳ vọng của bạn để
```

```
có thể phát triển thêm The VR Labs):
```

103
CHƯƠNG B. PHIẾU KHẢO SÁT ỨNG DỤNG THE VR LABS
Câu hỏi 5.3: Bạn thấy điểm nào ở ứng dụng VR không bằng học lý thuyết
truyền thống:
Câu hỏi 5.4: Bạn thấy điểm nào ở ứng dụng VR hơn học lý thuyết truyền
thống:
Câu hỏi 5.5: Bạn thử nghiệm bài giảng nào, bao nhiêu lần, trong bao lâu để
hiểu và ứng dụng?
Cảm ơn đã hoàn thành khảo sát!
Mọi thông tin bạn cung cấp chỉ được phục vụ cho mục đích nghiên cứu trong
khuôn khổ đồ án. Tôi trân trọng mọi đóng góp của bạn và cam kết bảo mật thông
tin cá nhân.
104
