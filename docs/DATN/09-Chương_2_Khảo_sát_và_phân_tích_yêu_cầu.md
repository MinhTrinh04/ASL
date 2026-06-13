# CHƯƠNG 2. KHẢO SÁT VÀ PHÂN TÍCH YÊU CẦU

## 2.1 Khảo sát hiện trạng

Để định hình một hướng giải pháp tối ưu và thực tiễn nhất, đồ án tiến hành khảo sát và phân tích hiện trạng các giải pháp học tập ASL hiện hành trên cả hai môi trường là các phương pháp học tập truyền thống và các ứng dụng VR có sẵn trên cửa hàng Meta Horizon Store.

### 2.1.1 Khảo sát phương pháp truyền thống

Đối với người nghe bình thường có mong muốn học ngôn ngữ ký hiệu để hỗ trợ cộng đồng khiếm thính, các phương pháp tiếp cận truyền thống bộc lộ những hạn chế đặc thù.

Đầu tiên, đối với phương thức học qua giáo trình in ấn và sách ảnh tĩnh, đây là phương pháp thụ động nhất khi người học chỉ tiếp xúc với hình ảnh chụp phẳng 2D ghi lại các tư thế tay tĩnh. Do ngôn ngữ ký hiệu là hệ thống giao tiếp đa chiều phức tạp, người học hoàn toàn gặp khó khăn trong việc hình dung cách gập các ngón tay trong không gian ba chiều hoặc hướng xoay lòng bàn tay (ví dụ như sự kết hợp cực kỳ nhỏ về chiều sâu giữa hai chữ cái U và V, hoặc hướng bàn tay giữa K và P rất khó mô tả bằng ảnh chụp phẳng).

Tiếp theo, đối với phương thức học qua video ghi hình sẵn, các video 2D dù cung cấp chuyển động liên tục của tay nhưng vẫn bị khóa cứng ở góc nhìn camera cố định. Người học không thể xoay nghiêng hoặc quan sát từ trên xuống để thấy rõ chiều sâu của cử chỉ. Quan trọng hơn, việc tự học trước màn hình phẳng hoàn toàn thiếu đi cơ chế tự đánh giá độ chính xác, người học không thể biết mình đã gập đúng khớp ngón tay hay chưa, dễ dẫn đến việc ghi nhớ sai lệch hệ thống cơ khớp.

### 2.1.2 Khảo sát ứng dụng thực tế ảo

Thị trường ứng dụng học tập ngôn ngữ ký hiệu trên nền tảng VR hiện nay đang chứng kiến một số nỗ lực thử nghiệm đáng ghi nhận nhằm khai thác công nghệ theo dõi tay không tay cầm. Việc phân tích sâu các sản phẩm này giúp nhận diện các giới hạn công nghệ hiện tại và đồng thời làm nổi bật những hạn chế cố hữu mà đồ án Bài giảng ngôn ngữ ký hiệu trong Thực tế ảo đặt mục tiêu khắc phục.

#### Gesture Play

Một trong những ứng dụng giáo dục tiên phong trong việc tiếp cận bảng chữ cái ASL bằng cử chỉ tay trần là Gesture Play (Hình 2.1). Trò chơi này hướng tới việc dạy bảng chữ cái thông qua hai chế độ tương tác chính là Practice Mode cung cấp một không gian thực hành tự do theo tiến trình của người học, và Game Mode thách thức người chơi nhận diện cử chỉ dưới áp lực thời gian để lấy điểm số. Điểm cộng lớn của ứng dụng là giao diện tối giản và khả năng phản hồi tương đối nhạy đối với các tư thế tay cơ bản, giúp người học nhanh chóng làm quen với thao tác không tay cầm.

![Chế độ Game Mode tính điểm và nhận diện cử chỉ tay trong Gesture Play](Hinhve/Chương%202/GP.png)

> **Hình 2.1:** Chế độ Game Mode tính điểm và nhận diện cử chỉ tay trong Gesture Play

Tuy nhiên, Gesture Play bộc lộ một điểm yếu chí mạng về mặt công nghệ: do giới hạn của các thuật toán so khớp xương tay, trò chơi bắt buộc phải loại bỏ hoàn toàn các chữ cái gồm J, M, N, P, Q, R, T, U, Z ra khỏi chương trình học. Việc khuyết thiếu gần 1/3 bảng chữ cái cốt lõi khiến ứng dụng hoàn toàn thất bại trong việc cung cấp một lộ trình học tập ASL trọn vẹn và chuẩn hóa. Hơn nữa, về mặt học liệu, Gesture Play chỉ dừng lại ở mức đánh vần bảng chữ cái đơn cô lập mà hoàn toàn thiếu vắng các từ vựng chủ đề thực tế như chữ số học thuật, các phép toán, hay các mẫu câu giao tiếp thông dụng hàng ngày. Sự thiếu sót nghiêm trọng về các chủ đề từ vựng này khiến người học dù làm chủ bảng chữ cái vẫn hoàn toàn bất lực trong việc giao tiếp thực tế với người khiếm thính.

![Hạn chế trong công nghệ nhận diện cử chỉ tay của Gesture Play](Hinhve/Chương%202/GP2.png)

> **Hình 2.2:** Hạn chế trong công nghệ nhận diện cử chỉ tay của Gesture Play

#### Sign Pose VR

Một đại diện đáng chú ý khác trên Meta Quest Store là Sign Pose VR (Hình 2.3), một công cụ học tập được thiết kế dành riêng cho người mới bắt đầu để rèn luyện độ chính xác của các tư thế tay ASL. Ứng dụng tích hợp Learn Mode cung cấp các viền mẫu tay chỉ dẫn chi tiết để người học uốn nắn bàn tay vật lý của mình và Quiz Mode để kiểm tra mức độ lưu giữ kiến thức. Ưu điểm lớn nhất của ứng dụng là đã trực quan hóa được hướng dẫn đặt các ngón tay và cung cấp phản hồi sửa sai tức thời đối với các tư thế tay tĩnh.

![Đặc tả khớp mẫu tay trong chế độ Learn Mode của Sign Pose VR](Hinhve/Chương%202/SP.png)

> **Hình 2.3:** Đặc tả khớp mẫu tay trong chế độ Learn Mode của Sign Pose VR

Mặc dù có thiết kế sư phạm khá rõ ràng, Sign Pose VR lại gặp rào cản lớn về mặt trải nghiệm người dùng và tính đa dạng nội dung. Hệ thống so khớp xương tay thô của ứng dụng cực kỳ nhạy cảm với các hiện tượng nhiễu cảm biến hoặc hiện tượng run tay vật lý của người học. Việc không tích hợp bất kỳ cơ chế đệm sai số hay cửa sổ miễn phạt nào khiến người học vô cùng ức chế khi chỉ một dịch chuyển rất nhỏ của ngón tay ngoài ý muốn cũng bị hệ thống đánh giá sai và phạt điểm trực tiếp. Đồng thời, giao diện của Sign Pose VR lạm dụng các bảng UI Canvas 2D phẳng lớn lơ lửng cố định trong không gian ảo, không chỉ gây che khuất tầm nhìn bắt khớp tay của camera kính HMD mà còn gây mệt mỏi nhận thức và xao nhãng rất lớn cho người học. Đáng nói nhất, tương tự như Gesture Play, Sign Pose VR bộc lộ sự thiếu sót sâu sắc về mặt học liệu thực hành khi hoàn toàn bỏ qua các bài học theo chủ đề đời sống, không có hệ thống chữ số 3D, từ ghép hay các đoạn hội thoại đa chiều, chỉ bó hẹp người học trong các bài kiểm tra ký tự đơn lẻ nhàm chán.

#### Nhận xét chung về khoảng trống thị trường

Từ việc phân tích các sản phẩm thực tế trên, có thể đưa ra nhận định chung rằng các ứng dụng VR học ngôn ngữ ký hiệu hiện hành đã mở ra hướng đi đầy tiềm năng cho việc dạy học tương tác tay trần. Tuy nhiên, chúng đều gặp phải các hạn chế lớn như: công nghệ bắt khớp tay thô sơ bỏ sót các cử chỉ động vẽ nét phức tạp do lỗi che khuất camera, giao diện UI Canvas cồng kềnh cản trước thao tác ngón tay, và đặc biệt là sự nghèo nàn, thiếu hụt nghiêm trọng về các chủ đề học liệu thực tế. Điều này khẳng định sự tồn tại khoảng trống lớn trên thị trường, một cơ hội mà đồ án **Bài giảng ngôn ngữ ký hiệu trong Thực tế ảo** đã khai thác triệt để bằng cách cung cấp một chương trình học ASL toàn diện 3 module (Bảng chữ cái, Bảng chữ số thực nghiệm, Mẫu câu giao tiếp), đi kèm các cơ chế trò chơi hóa bảo vệ tâm lý người học.

Để làm nổi bật giá trị giải pháp của đồ án, bảng dưới đây so sánh chi tiết đặc tính kỹ thuật và tương tác:

#### Bảng 2.1: So sánh tính năng tương tác của giải pháp đề xuất với các ứng dụng hiện tại

| Tính năng so sánh                  | Tài liệu truyền thống                         | Ứng dụng ASL VR hiện tại trên Store               | Giải pháp đề xuất của đồ án                                            |
| :--------------------------------- | :-------------------------------------------- | :------------------------------------------------ | :--------------------------------------------------------------------- |
| **Không gian tương tác**           | 2D phẳng tĩnh hoặc động bị khóa góc camera    | 3D lập thể trong không gian ảo                    | 3D lập thể nhập vai chuyên biệt                                        |
| **Phương thức tương tác**          | Đọc/Xem thụ động, không tương tác trực tiếp   | Dùng tay cầm hoặc cử chỉ tĩnh rất cơ bản          | Tương tác hoàn toàn bằng bàn tay vật lý trần                           |
| **Độ trễ và phản hồi**             | Không có phản hồi đánh giá cử chỉ             | Phản hồi chậm, dễ mất dấu khi tay di chuyển nhanh | Phản hồi thời gian thực tức thì kèm trực quan hóa màu sắc              |
| **Nhận diện cử chỉ động vẽ nét**   | Không hỗ trợ                                  | Không hỗ trợ                                      | Hỗ trợ chính xác cao nhờ thuật toán **$1 Unistroke**                   |
| **Cơ chế thi cử**                  | Thi trắc nghiệm giấy hoặc ứng dụng điện thoại | Thi trắc nghiệm chọn đáp án bằng nút bấm tay cầm  | Thi thực hành đánh vần chuỗi từ thực tế, điền từ vào chỗ trống         |
| **Thiết kế UI/UX chống xao nhãng** | Không áp dụng                                 | UI Canvas phẳng lơ lửng gây cản trở tương tác tay | Bảng đeo tay phía trên cổ tay và bảng thông tin tự hướng theo góc nhìn |
| **Cơ chế giảm áp lực phòng thi**   | Không có                                      | Sai là phạt điểm trực tiếp                        | Tích hợp **Hidden Mistakes**, **Invincibility Window** giảm ức chế     |

## 2.2 Mục đích của bài giảng

Việc xây dựng ứng dụng thực tế ảo dưới dạng một trò chơi giáo dục hướng tới giải quyết triệt để các rào cản cốt lõi mà người học thường xuyên đối mặt trong các phương pháp tiếp cận truyền thống. Trong học tập ngôn ngữ ký hiệu ASL, vấn đề lớn nhất là người học gặp rất nhiều khó khăn khi phải ghi nhớ và thực hiện chính xác các động tác tay phức tạp chỉ thông qua các tài liệu truyền thống như sách ảnh tĩnh hoặc video hướng dẫn. Các phương pháp tĩnh này hoàn toàn bất lực trong việc truyền tải chiều sâu không gian của tư thế tay, vị trí so khớp với cơ thể và quỹ đạo chuyển động liên tục của cử chỉ. Người học dễ rơi vào trạng thái nản lòng, mệt mỏi do thiếu môi trường thực hành đa chiều tương tác và không hề nhận được bất kỳ phản hồi sửa sai tức thời nào từ giáo viên hướng dẫn, dẫn đến việc ghi nhớ sai lệch hệ cơ khớp ngón tay. Ngoài ra, sự khô khan của các bài tập uốn tay lặp đi lặp lại nhanh chóng triệt tiêu động lực học tập, đặc biệt là với những người tự học tại nhà.

Trước những thách thức đặc thù đó, trò chơi được thiết kế với mục tiêu sư phạm rõ ràng nhằm biến quá trình rèn luyện ngôn ngữ ký hiệu thành một trải nghiệm học tập chủ động và giàu tương tác. Dựa trên nền tảng thuyết học tập trải nghiệm của David Kolb và nón trải nghiệm của Edgar Dale, trò chơi hướng tới việc kích hoạt chu trình học sâu thông qua hành động vật lý trực tiếp. Bằng việc sử dụng chính đôi bàn tay trần trong môi trường VR, người học không còn tiếp thu kiến thức một cách thụ động bằng mắt mà được trực tiếp tham gia vào một vòng lặp trải nghiệm sinh động. Trò chơi thiết lập một vòng lặp phản hồi siêu tốc bằng màu sắc tương phản trực quan để người học nhận biết ngay lập tức kết quả cử chỉ tay của mình, từ đó tự động điều chỉnh cơ khớp ngón tay cho đến khi hoàn toàn khớp với mẫu. Đồng thời, việc tích hợp các giao diện tương tác tối giản như bảng điều khiển cổ tay ẩn và slide bài giảng tự động hướng mặt người học giúp loại bỏ mọi tác nhân gây xao nhãng thị giác, giải phóng không gian lớp học ảo để người học tập trung hoàn toàn nhận thức vào cử chỉ mẫu của nhân vật giảng viên ảo Kyle.

Song song với mục tiêu sư phạm, trò chơi hướng tới việc xây dựng một cây cầu công nghệ nhân văn giúp thu hẹp khoảng cách giao tiếp giữa cộng đồng người nghe bình thường và cộng đồng người khiếm thính. Bằng việc hạ thấp rào cản tiếp cận ngôn ngữ ký hiệu và tạo ra một phương thức tự học ASL miễn phí, hấp dẫn tại nhà, đồ án mong muốn khuyến khích một lượng lớn tình nguyện viên, học sinh, sinh viên và người thân của người khiếm thính tham gia học tập. Tác động lâu dài của ứng dụng là nâng cao nhận thức cộng đồng về giáo dục đặc biệt, hỗ trợ quá trình hòa nhập xã hội toàn diện của người khuyết tật, đồng thời đặt những viên gạch nền móng đầu tiên cho việc phát triển các học liệu tương tác cử chỉ tay trần ứng dụng công nghệ giáo dục EdTech tiên tiến tại Việt Nam.

## 2.3 Định hướng sử dụng

Định hướng sử dụng cốt lõi của "Bài giảng ngôn ngữ ký hiệu trong Thực tế ảo" là đóng vai trò như một phòng thực nghiệm tương tác bổ trợ giúp thu hẹp khoảng cách giữa lý thuyết giảng dạy và thực hành uốn nắn cơ khớp ngón tay thực tế. Thay vì hoạt động như một ứng dụng giải trí độc lập hoàn toàn hay thay thế hoàn toàn vai trò của con người, trò chơi được thiết kế để tích hợp trực tiếp vào kịch bản sư phạm kết hợp: học sinh tiếp thu lý thuyết ngôn ngữ ký hiệu và ngữ pháp từ giáo viên hướng dẫn, sau đó sử dụng môi trường thực tế ảo làm không gian thực hành cá nhân hóa để uốn nắn và khắc sâu các tư thế tay vật lý thành trí nhớ cơ bắp.

Ý tưởng này giải quyết triệt để hạn chế lớn nhất trong giảng dạy ngôn ngữ ký hiệu đặc biệt là sự thiếu hụt nghiêm trọng thời gian tương tác trực tiếp một-một giữa giáo viên và học sinh. Trong không gian lớp học truyền thống, một giáo viên rất khó chỉnh sửa chi tiết từng khớp ngón tay cho hàng chục học sinh cùng lúc, dẫn đến việc học sinh dễ hình thành thói quen sai lệch động tác. Trò chơi đóng vai trò như một trợ giảng ảo đắc lực tại lớp hoặc tại nhà: khi học sinh thực hiện cử chỉ trước kính VR, hệ thống sẽ tự động so khớp, tô màu phản hồi tức thời để học sinh tự điều chỉnh, trong khi người hướng dẫn thực tế chỉ cần đóng vai trò giám sát, hỗ trợ uốn nắn các ca khó.

Sự linh hoạt này cho phép trò chơi dễ dàng dịch chuyển giữa môi trường lớp học chuyên biệt – nơi nó hoạt động như một giáo cụ bổ trợ trực quan sinh động dưới sự điều phối của giáo viên – và môi trường tự học độc lập tại nhà, nơi người học có thể tự chủ động luyện tập và làm các bài đánh giá theo nhịp độ nhận thức cá nhân. Bằng cách định vị như một công cụ bổ trợ phòng thực nghiệm ảo linh hoạt, trò chơi tối ưu hóa tối đa hiệu năng sư phạm, giúp giảm tải áp lực giảng dạy lặp đi lặp lại của giảng viên, đồng thời mang lại cho học sinh một không gian thử và sai an toàn, hiệu quả để nhanh chóng làm chủ ngôn ngữ ký hiệu ASL.

## 2.4 Cơ sở của định hướng sử dụng

Định hướng sử dụng bài giảng như một phòng thực nghiệm ảo tương tác bổ trợ được xây dựng dựa trên các cơ sở khoa học sư phạm vững chắc cùng các yêu cầu kỹ thuật phi chức năng chặt chẽ. Về mặt lý thuyết giáo dục tương tác, hệ thống dựa trên nón trải nghiệm của Edgar Dale để thúc đẩy phương pháp học tập qua hành động trực tiếp. Bằng việc luyện tập bằng đôi bàn tay trần vật lý trước cảm biến, người học được kích hoạt sâu sắc vùng trí nhớ vận động cơ bắp, giúp gia tăng tỷ lệ ghi nhớ kiến thức dài hạn lên tới chín mươi phần trăm so với việc chỉ tiếp thu thụ động. Đồng thời, học thuyết học tập trải nghiệm của David Kolb đóng vai trò then chốt trong việc thiết lập chu trình phản hồi nhận thức bốn bước khép kín. Người học bắt đầu bằng việc quan sát tư thế tay mẫu của giảng viên ảo Kyle, nhận phản hồi màu sắc trực quan ngay tức thì qua bảng điều khiển đeo tay hoặc bảng câu đố thi tự hướng theo góc nhìn, so sánh đối chiếu để tự khái quát hóa lại góc khớp ngón tay và chủ động thực nghiệm tư thế mới. Vòng lặp tuần hoàn này giúp người học tự sửa sai liên tục và làm chủ ngôn ngữ ký hiệu một cách tự nhiên.

Bên cạnh nền tảng lý thuyết sư phạm, việc vận hành bài giảng còn đòi hỏi các tiêu chuẩn kỹ thuật phi chức năng vô cùng nghiêm ngặt để đảm bảo an toàn sinh học và tính mượt mà khi tương tác. Trước hết, hệ thống bắt buộc phải duy trì mức hiệu suất khung hình ổn định từ 72 đến 90 hình trên giây trực tiếp trên thiết bị kính độc lập Meta Quest. Việc sụt giảm tốc độ dựng hình sẽ ngay lập tức phá vỡ chu trình phản hồi nhận thức, đồng thời gây ra hội chứng say thực tế ảo nghiêm trọng cho học viên. Song song đó, độ trễ phản hồi từ thời điểm người học thay đổi cử chỉ ngón tay vật lý cho đến khi hệ thống nhận diện và cập nhật tín hiệu trực quan trên màn hình bắt buộc phải duy trì xuyên suốt để đảm bảo tính tương tác thời gian thực tức thì, tạo cảm giác chuyển động tự nhiên nhất cho bàn tay ảo. Cuối cùng, độ chính xác của bộ nhận dạng cử chỉ phải đạt tỷ lệ tối thiểu tám mươi lăm phần trăm đối với cả tư thế tay tĩnh lẫn nét vẽ quỹ đạo động phức tạp. Yêu cầu này giúp hạn chế tối đa các đánh giá sai lệch ngoài ý muốn từ cảm biến phần cứng, ngăn chặn sự ức chế tâm lý và duy trì động lực tự học lâu dài cho học viên.
