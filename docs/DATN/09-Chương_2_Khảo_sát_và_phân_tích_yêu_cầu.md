# CHƯƠNG 2. KHẢO SÁT VÀ PHÂN TÍCH YÊU CẦU

## 2.1 Khảo sát hiện trạng

Để định hình một hướng giải pháp tối ưu và thực tiễn nhất, đồ án tiến hành khảo sát và phân tích hiện trạng các giải pháp học tập Ngôn ngữ ký hiệu Mỹ (ASL) hiện hành trên cả hai môi trường: các phương pháp học tập truyền thống và các ứng dụng thực tế ảo (VR) có sẵn trên cửa hàng Meta Horizon Store.

### 2.1.1 Khảo sát các giải pháp học tập ngôn ngữ ký hiệu truyền thống (2D)

Đối với người nghe bình thường có mong muốn học ngôn ngữ ký hiệu để hỗ trợ cộng đồng khiếm thính (như tình nguyện viên, người thân hoặc nhà giáo dục đặc biệt), các phương pháp tiếp cận truyền thống bộc lộ những hạn chế đặc thù:

- **Học qua giáo trình in ấn và sách ảnh tĩnh**: Đây là phương pháp thụ động nhất. Người học chỉ tiếp xúc với hình ảnh chụp phẳng 2D ghi lại các tư thế tay tĩnh. Do ngôn ngữ ký hiệu là hệ thống giao tiếp đa chiều phức tạp, người học hoàn toàn gặp khó khăn trong việc hình dung cách gập các ngón tay trong không gian ba chiều hoặc hướng xoay lòng bàn tay (ví dụ: sự kết hợp cực kỳ nhỏ về chiều sâu giữa hai chữ cái `U` và `V`, hoặc hướng bàn tay giữa `K` và `P` rất khó mô tả bằng ảnh chụp phẳng).
- **Học qua video ghi hình sẵn (Youtube / Ứng dụng di động)**: Video 2D cung cấp chuyển động liên tục của tay nhưng bị khóa cứng ở góc nhìn camera cố định. Người học không thể xoay nghiêng hoặc quan sát từ trên xuống để thấy rõ chiều sâu của cử chỉ. Quan trọng hơn, việc tự học trước màn hình phẳng hoàn toàn thiếu đi cơ chế tự đánh giá độ chính xác, người học không thể biết mình đã gập đúng khớp ngón tay hay chưa, dễ dẫn đến việc ghi nhớ sai lệch hệ thống cơ khớp (muscle memory).

### 2.1.2 Khảo sát các ứng dụng học ngôn ngữ ký hiệu trong Thực tế ảo hiện hành

Thị trường ứng dụng học tập ngôn ngữ ký hiệu trên nền tảng thực tế ảo (VR) hiện nay đang chứng kiến một số nỗ lực thử nghiệm đáng ghi nhận nhằm khai thác công nghệ theo dõi tay không tay cầm (Controller-free Hand Tracking). Việc phân tích sâu các sản phẩm này giúp nhận diện các giới hạn công nghệ hiện tại và đồng thời làm nổi bật những hạn chế cố hữu mà đồ án "Bài giảng ngôn ngữ ký hiệu trong Thực tế ảo" đặt mục tiêu khắc phục.

#### a, Gesture Play

Một trong những ứng dụng giáo dục tiên phong trong việc tiếp cận bảng chữ cái ASL bằng cử chỉ tay trần là Gesture Play (Hình 2.1) [1]. Trò chơi này hướng tới việc dạy bảng chữ cái thông qua hai chế độ tương tác chính: "Practice Mode" cung cấp một không gian thực hành tự do theo tiến trình của người học, và "Game Mode" thách thức người chơi nhận diện cử chỉ dưới áp lực thời gian để lấy điểm số. Điểm cộng lớn của ứng dụng là giao diện tối giản và khả năng phản hồi tương đối nhạy đối với các tư thế tay cơ bản, giúp người học nhanh chóng làm quen với thao tác không tay cầm.

- **[HÌNH 2.1]**: _Chế độ Game Mode tính điểm và nhận diện cử chỉ tay trong Gesture Play [2]_

Tuy nhiên, Gesture Play bộc lộ một điểm yếu chí mạng về mặt công nghệ bắt khớp tay: do giới hạn của các thuật toán so khớp xương tay truyền thống gặp hiện tượng che khuất camera (occlusion) và chồng chéo ngón tay, trò chơi bắt buộc phải loại bỏ hoàn toàn 8 chữ cái gồm J, M, N, P, Q, R, T, U ra khỏi chương trình học. Việc khuyết thiếu gần 1/3 bảng chữ cái cốt lõi khiến ứng dụng hoàn toàn thất bại trong việc cung cấp một lộ trình học tập ASL trọn vẹn và chuẩn hóa. Đặc biệt, trò chơi hoàn toàn bất lực trước việc nhận diện cử chỉ động vẽ nét trong không gian (như chữ J) - vốn là khía cạnh mà đồ án của chúng tôi giải quyết thành công qua thuật toán $1 Unistroke. Hơn thế nữa, về mặt học liệu, Gesture Play chỉ dừng lại ở mức đánh vần bảng chữ cái đơn cô lập mà hoàn toàn thiếu vắng các từ vựng chủ đề thực tế như chữ số học thuật, các phép toán thực nghiệm, hay các mẫu câu giao tiếp thông dụng hàng ngày. Sự thiếu sót nghiêm trọng về các chủ đề từ vựng này khiến người học dù làm chủ bảng chữ cái vẫn hoàn toàn bất lực trong việc giao tiếp thực tế với người khiếm thính.

#### b, Sign Pose VR

Một đại diện đáng chú ý khác trên Meta Quest Store là Sign Pose VR (Hình 2.2) [3], một công cụ học tập được thiết kế dành riêng cho người mới bắt đầu để rèn luyện độ chính xác của các tư thế tay ASL. Ứng dụng tích hợp "Learn Mode" cung cấp các sơ đồ chỉ dẫn khớp xương tay 3D chi tiết để người học uốn nắn bàn tay vật lý của mình và "Quiz Mode" để kiểm tra mức độ lưu giữ kiến thức. Ưu điểm lớn nhất của ứng dụng là đã trực quan hóa được hướng dẫn đặt các ngón tay và cung cấp phản hồi sửa sai tức thì đối với các tư thế tay tĩnh.

- **[HÌNH 2.2]**: _Đặc tả khớp xương tay hướng dẫn trong chế độ Learn Mode của Sign Pose VR [3]_

Mặc dù có thiết kế sư phạm khá rõ ràng, Sign Pose VR lại gặp rào cản lớn về mặt trải nghiệm người dùng và tính đa dạng nội dung. Hệ thống so khớp xương tay thô của ứng dụng cực kỳ nhạy cảm với các hiện tượng nhiễu cảm biến (sensor drift) hoặc hiện tượng run tay vật lý của người học. Việc không tích hợp bất kỳ cơ chế đệm sai số hay cửa sổ miễn phạt nào khiến người học vô cùng ức chế khi chỉ một dịch chuyển rất nhỏ của ngón tay ngoài ý muốn cũng bị hệ thống đánh giá sai và phạt điểm trực tiếp. Đồng thời, giao diện của Sign Pose VR lạm dụng các bảng UI Canvas 2D phẳng lớn lơ lửng cố định trong không gian ảo, không chỉ gây che khuất tầm nhìn bắt khớp tay của camera kính HMD mà còn làm tăng đáng kể tải nhận thức của người học. Đáng nói nhất, tương tự như Gesture Play, Sign Pose VR bộc lộ sự thiếu sót sâu sắc về mặt học liệu thực hành khi hoàn toàn bỏ qua các bài học theo chủ đề đời sống, không có hệ thống chữ số 3D, từ ghép hay các đoạn hội thoại đa chiều, chỉ bó hẹp người học trong các bài kiểm tra ký tự đơn lẻ nhàm chán.

#### Nhận xét chung về khoảng trống thị trường

Từ việc phân tích các sản phẩm thực tế trên, có thể đưa ra nhận định chung rằng các ứng dụng VR học ngôn ngữ ký hiệu hiện hành đã mở ra hướng đi đầy tiềm năng cho việc dạy học tương tác tay trần. Tuy nhiên, chúng đều gặp phải các hạn chế lớn như: công nghệ bắt khớp tay thô sơ bỏ sót các cử chỉ động vẽ nét phức tạp do lỗi che khuất camera, giao diện UI Canvas 2D cồng kềnh cản trở thao tác ngón tay, và đặc biệt là sự nghèo nàn, thiếu hụt nghiêm trọng về các chủ đề học liệu thực tế (chữ số, phép toán, mẫu câu giao tiếp). Điều này khẳng định sự tồn tại của một "khoảng trống" lớn trên thị trường, một cơ hội mà đồ án **"Bài giảng ngôn ngữ ký hiệu trong Thực tế ảo"** của Trịnh Quang Minh đã khai thác triệt để bằng cách cung cấp một chương trình học ASL toàn diện 3 module (Bảng chữ cái với thuật toán vẽ nét $1 Unistroke, Bảng chữ số thực nghiệm, Mẫu câu giao tiếp), đi kèm các cơ chế trò chơi hóa bảo vệ tâm lý người học như Hidden Mistakes, Invincibility Window và giao diện Wrist Dashboard tối giản hướng mặt người chơi.

---

Để làm nổi bật giá trị giải pháp của đồ án, bảng dưới đây so sánh chi tiết đặc tính kỹ thuật và tương tác:

#### Bảng 2.1: So sánh tính năng tương tác của giải pháp đề xuất với các ứng dụng hiện tại

| Tính năng so sánh                       | Sách ảnh / Video 2D truyền thống              | Ứng dụng ASL VR hiện tại trên Store                   | Giải pháp đề xuất của đồ án (**ASL VR Game**)                      |
| --------------------------------------- | --------------------------------------------- | ----------------------------------------------------- | ------------------------------------------------------------------ |
| **Không gian tương tác**                | 2D phẳng tĩnh hoặc động bị khóa góc camera    | 3D lập thể trong không gian ảo                        | 3D lập thể nhập vai chuyên biệt                                    |
| **Phương thức tương tác**               | Đọc/Xem thụ động, không tương tác trực tiếp   | Dùng tay cầm (Controller) hoặc cử chỉ tĩnh rất cơ bản | Tương tác hoàn toàn bằng bàn tay vật lý trần (**Controller-free**) |
| **Độ trễ và phản hồi**                  | Không có phản hồi đánh giá cử chỉ             | Phản hồi chậm, dễ mất dấu khi tay di chuyển nhanh     | Phản hồi thời gian thực tức thì (< 0.2s) kèm trực quan hóa màu sắc |
| **Nhận diện cử chỉ động vẽ nét (J, Z)** | Không hỗ trợ                                  | Không hỗ trợ (Bị mất dấu khớp ngón tay)               | Hỗ trợ chính xác cao nhờ thuật toán **$1 Unistroke**               |
| **Cơ chế thi cử (Quiz)**                | Thi trắc nghiệm giấy hoặc ứng dụng điện thoại | Thi trắc nghiệm chọn đáp án bằng nút bấm tay cầm      | Thi thực hành đánh vần chuỗi từ thực tế, điền từ vào chỗ trống     |
| **Thiết kế UI/UX chống tải nhận thức**  | Không áp dụng                                 | UI Canvas phẳng lơ lửng gây cản trở tương tác tay     | Menu lật cổ tay ẩn (**Wrist Dashboard**) và Billboard hướng mặt    |
| **Cơ chế giảm áp lực phòng thi**        | Không có                                      | Không có (Sai là phạt điểm trực tiếp)                 | Tích hợp **Hidden Mistakes**, **Invincibility Window** giảm ức chế |

---

## 2.2 Mục đích của bài giảng

Việc xây dựng ứng dụng thực tế ảo dưới dạng một trò chơi giáo dục hướng tới giải quyết triệt để các rào cản cốt lõi mà người học thường xuyên đối mặt trong các phương pháp tiếp cận truyền thống. Trong học tập ngôn ngữ ký hiệu ASL, vấn đề lớn nhất là người học gặp rất nhiều khó khăn khi phải ghi nhớ và thực hiện chính xác các động tác tay phức tạp chỉ thông qua các tài liệu 2D phẳng như sách ảnh tĩnh hoặc video hướng dẫn. Các phương pháp tĩnh này hoàn toàn bất lực trong việc truyền tải chiều sâu không gian của tư thế tay, vị trí so khớp với cơ thể và quỹ đạo chuyển động liên tục của cử chỉ. Người học dễ rơi vào trạng thái nản lòng, mệt mỏi do thiếu môi trường thực hành đa chiều tương tác và không hề nhận được bất kỳ phản hồi sửa sai tức thời nào từ giáo viên hướng dẫn, dẫn đến việc ghi nhớ sai lệch hệ cơ khớp ngón tay. Ngoài ra, sự khô khan của các bài tập uốn tay lặp đi lặp lại nhanh chóng triệt tiêu động lực học tập, đặc biệt là với những người tự học tại nhà.

Trước những thách thức đặc thù đó, trò chơi được thiết kế với mục tiêu sư phạm rõ ràng nhằm biến quá trình rèn luyện ngôn ngữ ký hiệu thành một trải nghiệm học tập chủ động và giàu tương tác. Dựa trên nền tảng thuyết học tập trải nghiệm của David Kolb và nón trải nghiệm của Edgar Dale, trò chơi hướng tới việc kích hoạt chu trình học sâu thông qua hành động vật lý trực tiếp. Bằng việc sử dụng chính đôi bàn tay trần trong môi trường VR 3D lập thể, người học không còn tiếp thu kiến thức một cách thụ động bằng mắt mà được trực tiếp tham gia vào một vòng lặp trải nghiệm sinh động. Trò chơi thiết lập một vòng lặp phản hồi siêu tốc bằng màu sắc tương phản trực quan để người học nhận biết ngay lập tức kết quả cử chỉ tay của mình, từ đó tự động điều chỉnh cơ khớp ngón tay cho đến khi hoàn toàn khớp với mẫu. Đồng thời, việc ứng dụng thuyết tải nhận thức của John Sweller vào thiết kế trò chơi giúp loại bỏ mọi tác nhân gây xao nhãng thị giác, giải phóng bộ nhớ làm việc của não bộ để người học tập trung hoàn toàn nhận thức vào cử chỉ mẫu của nhân vật giảng viên ảo.

<!-- Song song với mục tiêu sư phạm, mục tiêu đào tạo cốt lõi của trò chơi là giúp người học làm chủ các kỹ năng thực hành ngôn ngữ ký hiệu theo một lộ trình phân cấp khoa học và toàn diện từ cơ bản đến nâng cao. Ở cấp độ nền tảng, trò chơi đào tạo khả năng nhận diện và thực hiện chính xác 26 ký tự đơn trong bảng chữ cái tiếng Anh, đặc biệt là huấn luyện phản xạ động học phức tạp thông qua việc vẽ nét trong không gian ảo đối với các chữ cái chuyển động như J và Z. Tiến xa hơn, trò chơi hướng tới rèn luyện khả năng đếm số, thực hiện các phép toán thực nghiệm ảo và phản xạ giao tiếp thông qua việc ghép nối các chuỗi cử chỉ tay trong không gian để diễn tả các cụm từ chào hỏi, cảm ơn hay hội thoại thông dụng hàng ngày. Quá trình kiểm tra đánh giá được thiết kế không phải để trừng phạt mà để củng cố kỹ năng thông qua các cơ chế bảo vệ tâm lý trò chơi hóa độc đáo như đệm sai số ẩn và cửa sổ vô địch, giúp người học thoải mái "thử và sai" để tự tin làm chủ kiến thức mà không bị ức chế hay lo âu. -->

Song song với mục tiêu sư phạm, trò chơi hướng tới việc xây dựng một cây cầu công nghệ nhân văn giúp thu hẹp khoảng cách giao tiếp giữa cộng đồng người nghe bình thường và cộng đồng người khiếm thính. Bằng việc hạ thấp rào cản tiếp cận ngôn ngữ ký hiệu và tạo ra một phương thức tự học ASL miễn phí, hấp dẫn tại nhà, đồ án mong muốn khuyến khích một lượng lớn tình nguyện viên, học sinh, sinh viên và người thân của người khiếm thính tham gia học tập. Tác động lâu dài của ứng dụng là nâng cao nhận thức cộng đồng về giáo dục đặc biệt, hỗ trợ quá trình hòa nhập xã hội toàn diện của người khuyết tật, đồng thời đặt những viên gạch nền móng đầu tiên cho việc phát triển các học liệu tương tác cử chỉ tay trần ứng dụng công nghệ giáo dục EdTech tiên tiến tại Việt Nam.

---

## 2.3 Định hướng sử dụng

Ứng dụng được định hình rõ ràng về đối tượng tiếp cận, không gian hoạt động và lộ trình phân cấp bài học để đạt hiệu quả sư phạm tối ưu.

### 2.3.1 Đối tượng người học và nhóm người dùng mục tiêu

Ứng dụng Bài giảng ngôn ngữ ký hiệu VR hướng tới các đối tượng cụ thể sau:

- **Người nghe bình thường từ 12 tuổi trở lên**: Có mong muốn học tập ngôn ngữ ký hiệu ASL để giao tiếp xã hội, tham gia hoạt động thiện nguyện hỗ trợ người khiếm thính.
- **Người thân, bạn bè hoặc giáo viên giáo dục đặc biệt**: Những người tiếp xúc trực tiếp hàng ngày với cộng đồng người khiếm thính và cần một công cụ tự luyện tập trực quan, sinh động để cải thiện kỹ năng giao tiếp không gian của mình.
- **Học sinh, sinh viên yêu thích công nghệ**: Nhóm người học mong muốn tiếp cận ngôn ngữ mới thông qua các phương thức tương tác thực tế ảo XR hiện đại thay cho sách vở khô khan.

### 2.3.2 Không gian triển khai và phương thức tiếp cận

- **Môi trường tự học tại nhà**: Người học sở hữu thiết bị kính VR độc lập (HMD standalone như Quest 2/3) có thể tự cài đặt ứng dụng và học tập trong một không gian an toàn, riêng tư, tự chủ động thời gian luyện tập mà không cần giáo viên đi kèm.
- **Lớp học chuyên biệt và trung tâm bảo trợ**: Ứng dụng đóng vai trò như một giáo cụ trực quan tiên tiến trong các giờ thực hành của các trường giáo dục đặc biệt, trung tâm ngôn ngữ ký hiệu, giúp giảm tải khối lượng giảng dạy lặp đi lặp lại của giáo viên hướng dẫn.
- **Các Lab nghiên cứu EdTech và thư viện số**: Nơi triển khai các mô hình lớp học tương tác ảo thế hệ mới nhằm đánh giá hiệu năng sư phạm thực nghiệm.

### 2.3.3 Lộ trình phân cấp nội dung bài học trong trò chơi

Để phù hợp với sự phát triển vận động của các khớp ngón tay và khả năng tiếp nhận nhận thức của người học, lộ trình bài học được thiết kế thành 3 phòng chuyên đề có độ khó tăng dần:

1. **Module Bảng chữ cái (Alphabets)**: Dạy nhận diện 26 ký tự đơn trong bảng chữ cái tiếng Anh. Đây là bài học nền tảng giúp làm quen với các tư thế ngón tay tĩnh và đặc biệt là kỹ thuật vẽ nét quỹ đạo động cho hai chữ cái phức tạp **`J`** và **`Z`**.
2. **Module Chữ số (Numbers)**: Thực hành các chữ số cơ bản từ 1 đến 10, kết hợp các bài toán đố vui số học thực nghiệm trong môi trường 3D để tăng tính phản xạ số hóa.
3. **Module Giao tiếp cơ bản (Greetings)**: Học các từ vựng hội thoại thông dụng (như Hello, Goodbye, Please, Thank you) đòi hỏi sự phối hợp chuyển động của cả hai bàn tay trong không gian và chuỗi cử chỉ thay đổi theo thời gian.

---

## 2.4 Cơ sở của định hướng sử dụng

Định hướng phát triển một trò chơi thực tế ảo tương tác tay trần (controller-free) thay thế cho các phương pháp truyền thống không phải là một sự lựa chọn ngẫu nhiên, mà được xây dựng vững chắc trên các cơ sở khoa học sư phạm, lý thuyết nhận thức và yêu cầu kỹ thuật thực nghiệm.

### 2.4.1 Cơ sở lý luận sư phạm EdTech (Edgar Dale's Cone of Experience)

Lý thuyết **Nón trải nghiệm của Edgar Dale** là nền tảng sư phạm quan trọng nhất chứng minh cho sự vượt trội của giải pháp VR tương tác tay trần:

- **Hạn chế của phương pháp cũ**: Sách ảnh (đọc ký tự) và video 2D (xem cử chỉ) nằm ở đỉnh nón trải nghiệm (học thụ động bằng mắt và tai), tỷ lệ ghi nhớ kiến thức chỉ đạt từ **10% đến 20%** sau hai tuần.
- **Giải pháp của đồ án**: Bằng việc đeo kính VR và sử dụng bàn tay trần để trực tiếp thực hành tư thế ký hiệu, người học được đặt ở **đáy nón trải nghiệm - Học thông qua hành động trực tiếp (Direct, Purposeful Experiences)**. Sự kết hợp giữa thị giác lập thể 3D và hoạt động cơ học của đôi bàn tay trần giúp tăng tỷ lệ ghi nhớ sâu sắc lên đến **90%**, giúp tạo lập phản xạ ghi nhớ cơ bắp nhanh gấp nhiều lần so với học chay.

### 2.4.2 Cơ sở tối ưu hóa nhận thức (Cognitive Load Theory in VR)

Để người học không bị quá tải thông tin khi ở trong môi trường VR 3D lập thể, đồ án áp dụng **Thuyết tải nhận thức của John Sweller** vào thiết kế giao diện tương tác:

- **Wrist Dashboard (Menu lật cổ tay)**: Menu tương tác và bảng tiến trình chỉ xuất hiện khi người chơi ngửa cổ tay một góc tự nhiên từ 60 - 90 độ, và tự động ẩn đi khi họ bắt đầu bài học. Điều này loại bỏ hoàn toàn các bảng UI 2D Canvas trôi nổi gây cản trở tầm nhìn tương tác của đôi tay, giúp dồn toàn bộ năng lực chú ý (working memory) của người học vào cử chỉ mẫu của Kyle.
- **UIFaceCamera (Billboard hướng mặt)**: Các nhãn chữ phản hồi luôn tự động xoay hướng trực diện về phía mắt người học, triệt tiêu tải nhận thức phát sinh do việc phải di chuyển đầu hoặc đứng sai góc để đọc chữ trong không gian ảo.

### 2.4.3 Cơ sở kỹ thuật phi chức năng và độ khả dụng thực nghiệm

Để định hướng sử dụng trên đạt hiệu quả thực tế và đảm bảo độ khả dụng sư phạm cao, ứng dụng bắt buộc phải đáp ứng các chỉ số kỹ thuật phi chức năng nghiêm ngặt được đo lường thực nghiệm:

- **Tốc độ khung hình (FPS) ổn định**: Phải đạt tối thiểu **72 FPS** (tối ưu ở **90 FPS**) trên kính Meta Quest 2 độc lập. Bất kỳ sự sụt giảm khung hình đột ngột nào dưới 60 FPS trong VR đều gây ra hiện tượng không khớp thông tin tiền đình (sensory conflict), dẫn đến say kính (motion sickness) và nhức đầu cho người học.
- **Độ trễ phản hồi thời gian thực (Latency)**: Thời gian từ lúc người học thực hiện động tác tay vật lý đến lúc hệ thống nhận diện và đổi màu chữ trên UI phải nhỏ hơn **0.2 giây**. Đây là giới hạn vàng để não bộ thiết lập liên kết phản hồi sinh học giữa hành động vật lý và kết quả thị giác.
- **Độ chính xác nhận diện và lọc nhiễu**: Hệ thống nhận dạng cử chỉ phải đạt tỉ lệ chính xác tối thiểu **85%** đối với cử chỉ tĩnh trong điều kiện ánh sáng bình thường, đồng thời lọc bỏ hoàn toàn các tư thế thả lỏng tự nhiên (`Idle`, `None`) của bàn tay để tránh đưa ra các phản hồi sai lệch gây bối rối cho người học.
