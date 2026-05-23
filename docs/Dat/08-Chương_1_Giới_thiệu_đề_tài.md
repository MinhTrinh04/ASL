# Chương 1: Giới Thiệu Đề Tài

## 1.1 Đặt vấn đề

Công nghệ thực tế ảo (Virtual Reality - **VR**) đã thúc đẩy sự phát triển mạnh mẽ của ngành công nghiệp game, đặc biệt với các thể loại yêu cầu tính tương tác cao như game bắn súng góc nhìn thứ nhất (First Person Shooter - **FPS**). Game FPS VR mang lại trải nghiệm nhập vai chân thực, nhưng các tựa game hiện nay chủ yếu dựa vào tay cầm điều khiển hoặc nút bấm ảo. Các phương thức này tạo ra khoảng cách giữa hành động thực tế và tương tác trong môi trường ảo, làm giảm tính nhập vai. 

Nghiên cứu từ Đại học **Würzburg** [1] chỉ ra rằng 76% người dùng VR mong muốn sử dụng cử chỉ tay tự nhiên thay vì các cơ chế điều khiển truyền thống. Sử dụng cử chỉ tay thay vì tay cầm truyền thống sẽ mở ra một hướng mới sáng tạo và có những lối chơi độc đáo hơn việc chỉ sử dụng tay cầm thông thường.

Giải quyết bài toán tích hợp cử chỉ tay vào game FPS VR sẽ mang lại nhiều lợi ích đáng kể:
* **Tăng cảm giác nhập vai:** Một hệ thống điều khiển trực quan dựa trên cử chỉ tay có thể tăng mức độ hứng thú của người chơi, đồng thời giảm thời gian làm quen so với các cơ chế nút bấm. 
* **Mở rộng đối tượng người dùng:** Người chơi có thể thực hiện các hành động như bắn súng, di chuyển một cách tự nhiên, nâng cao cảm giác nhập vai và dễ tiếp cận với cả những người không quen với tay cầm điều khiển truyền thống.
* **Tạo tính cạnh tranh:** Các nhà phát triển game cũng sẽ hưởng lợi từ việc tạo ra trải nghiệm độc đáo, tăng sức cạnh tranh trên thị trường VR.

Hơn nữa, giải pháp này không chỉ giới hạn trong lĩnh vực trò chơi. Công nghệ nhận diện cử chỉ tay có tiềm năng ứng dụng trong các lĩnh vực như đào tạo quân sự, mô phỏng y tế hoặc giao diện điều khiển công nghiệp. Nó còn mở ra khả năng phát triển các giao diện đa phương thức kết hợp cử chỉ, giọng nói và ánh mắt, cũng như tạo nền tảng cho việc cá nhân hóa gameplay thông qua thư viện cử chỉ mở. Do đó, phát triển một tựa game VR FPS sử dụng cử chỉ tay không chỉ đáp ứng nhu cầu cải thiện trải nghiệm người chơi mà còn đặt nền móng cho việc tiêu chuẩn hóa giao diện VR, thúc đẩy đổi mới công nghệ trong nhiều ngành.

## 1.2 Mục tiêu đề tài

Mục tiêu của đề tài là phát triển một tựa game bắn súng góc nhìn thứ nhất tiên phong trong lĩnh vực thực tế ảo, mang lại trải nghiệm tương tác chân thực và hấp dẫn. Đề tài tập trung khắc phục hạn chế của các cơ chế điều khiển tay cầm truyền thống bằng cách tích hợp tương tác cử chỉ tay. Hệ thống cho phép người chơi thực hiện các hành động như bắn súng, di chuyển, chạy nhanh và né tránh thông qua các cử chỉ tự nhiên, bao gồm trỏ tay, tạo hình khẩu súng bằng tay, hoặc mở lòng bàn tay. Các cử chỉ được thiết kế trực quan, dễ thực hiện, giúp người chơi nhanh chóng làm quen và tăng hứng thú khi trải nghiệm.

Bên cạnh đó, đề tài mở rộng tính ứng dụng bằng việc tích hợp điều khiển phương tiện, cụ thể là phi thuyền không gian, thông qua cử chỉ tay. Người chơi có thể nghiêng tàu sang trái hoặc phải, di chuyển hoặc nâng tàu bằng các thao tác tay riêng biệt. Tính năng này không chỉ tăng cường trải nghiệm nhập vai mà còn làm phong phú cơ chế gameplay, tận dụng tối đa không gian ba chiều của VR. Trò chơi được xây dựng trên nền tảng đồ họa **3D**, với công nghệ **VR** đảm bảo môi trường ảo đạt độ chân thực cao, tạo cảm giác hòa nhập cho người chơi.

Phạm vi đề tài bao gồm các chức năng chính:
* **(i) Tương tác cử chỉ tay:** Phát triển thư viện cử chỉ tay để thực hiện các hành động như bắn súng, di chuyển, chạy nhanh và né tránh, đảm bảo độ chính xác và phản hồi nhanh.
* **(ii) Điều khiển phương tiện:** Tích hợp cơ chế điều khiển tàu bay bằng cử chỉ tay, bao gồm các thao tác nghiêng, di chuyển và nâng tàu.
* **(iii) Hệ thống AI kẻ địch:** Xây dựng hệ thống AI sử dụng **NavMesh Agent** để kẻ địch tự động tìm kiếm và tấn công người chơi, tăng tính thử thách và tương tác động.
* **(iv) Môi trường 3D nhập vai:** Xây dựng thế giới game **3D** với công nghệ **VR**, tối ưu hóa trải nghiệm nhập vai và tương tác không gian.

Các tính năng được lựa chọn vì tính trực quan, dễ áp dụng, giúp người chơi nhanh chóng nắm bắt cơ chế và duy trì sự hứng thú. Đề tài không chỉ hướng đến việc nâng cao trải nghiệm chơi game mà còn đặt nền móng cho các ứng dụng tương tác cử chỉ tay trong các lĩnh vực khác, như mô phỏng đào tạo hoặc giao diện điều khiển không cần thiết bị vật lý. Hệ thống được thiết kế để dễ dàng tích hợp vào các nền tảng VR phổ biến, đảm bảo khả năng mở rộng và ứng dụng thực tế trong tương lai.

## 1.3 Phạm vi và đối tượng người sử dụng

Tựa game FPS VR được thiết kế để mang lại trải nghiệm hấp dẫn cho người chơi từ 15 tuổi trở lên, không phân biệt giới tính hay quốc tịch. Bối cảnh trò chơi mang phong cách hoạt hình, đa dạng và không chứa yếu tố bạo lực, máu me, ánh sáng nhấp nháy hay tiếng ồn lớn, đảm bảo thân thiện với mọi lứa tuổi và phù hợp cho người có tình trạng sức khỏe bình thường. Yếu tố này giúp trò chơi thu hút cả trẻ em, người lớn và những người yêu thích các trải nghiệm nhập vai nhẹ nhàng.

Các thao tác cử chỉ tay, như bắn súng, di chuyển hay điều khiển phương tiện, yêu cầu phản xạ nhanh, giúp tăng sự hứng thú cho người chơi đã quen với cơ chế VR. Yếu tố nhập vai được củng cố bởi môi trường 3D chân thực, tạo ấn tượng sâu sắc với bối cảnh trò chơi và thu hút những người yêu thích khám phá thế giới ảo.

Tuy nhiên, trò chơi sử dụng nhiều chuyển động trong không gian VR, có thể gây chóng mặt hoặc say VR, đặc biệt với những người chưa từng trải nghiệm VR trước đây. Do đó, trò chơi phù hợp hơn với người chơi đã có kinh nghiệm VR hoặc sẵn sàng làm quen với công nghệ này. Các trung tâm giải trí VR cũng là đối tượng tiềm năng, vì trò chơi có thể được sử dụng như một sản phẩm giải trí độc đáo, thu hút khách hàng nhờ tính tương tác cao và không gian nhập vai.

## 1.4 Định hướng giải pháp

### 1.4.1 Định hướng công nghệ

Để đạt mục tiêu mang lại trải nghiệm nhập vai chân thực và tương tác cao trong tựa game bắn súng góc nhìn thứ nhất FPS VR, đồ án triển khai một hệ thống tích hợp các công nghệ tiên tiến:
* **Thư viện Gesture:** Được sử dụng để trích xuất và nhận diện các cử chỉ tay, cho phép ghi nhận chính xác các thao tác phức tạp như trỏ tay, tạo hình khẩu súng, mở lòng bàn tay, hoặc thực hiện các động tác điều khiển phương tiện. Thư viện này dựa trên các mô hình học máy được huấn luyện trước, đảm bảo độ nhạy cao và giảm thiểu tỷ lệ nhầm lẫn lệnh, đáp ứng yêu cầu về phản hồi nhanh trong môi trường game hành động.
* **Unity 3D:** Được lựa chọn để xây dựng môi trường trò chơi ba chiều với đồ họa chi tiết, tái hiện không gian ảo sống động, từ các khu vực chiến đấu đến cảnh quan vũ trụ. Unity 3D hỗ trợ tối ưu hóa hiệu suất trên các nền tảng VR phổ biến, đảm bảo trải nghiệm mượt mà ngay cả trên các thiết bị cấu hình trung bình.
* **Hệ thống vật lý Unity:** Được áp dụng để mô phỏng chuyển động của phi thuyền, tái hiện chính xác các hành vi như nghiêng, nâng, hoặc di chuyển trong không gian ba chiều, mang lại cảm giác điều khiển chân thực.
* **NavMesh Agent:** Hệ thống AI kẻ địch sử dụng NavMesh Agent - một công cụ của Unity cho phép tạo ra các hành vi thông minh như tự động tìm đường, xác định vị trí người chơi, và thực hiện các chiến thuật tấn công đa dạng, từ bắn súng trực diện đến di chuyển né tránh. Công nghệ này đảm bảo tính thử thách của trò chơi, đồng thời tăng cường sự tương tác động giữa người chơi và môi trường ảo.

### 1.4.2 Mô tả giải pháp

Giải pháp được xây dựng dựa trên các khảo sát về nhu cầu tương tác và trải nghiệm trong các tựa game FPS VR, đặc biệt là mong muốn sử dụng cử chỉ tay thay vì tay cầm truyền thống. 

Hệ thống cử chỉ tay sử dụng thư viện **Gesture Recognition** để nhận diện các thao tác tay phức tạp, như trỏ tay để di chuyển, tạo hình khẩu súng để bắn, hoặc mở lòng bàn tay để né tránh. Các cử chỉ được ánh xạ trực tiếp với hành động trong game, đảm bảo tính trực quan và giảm thời gian làm quen.

Cơ chế điều khiển phi thuyền được phát triển dựa trên các hàm vật lý của Unity giúp điều chỉnh lực đẩy để mô phỏng chuyển động bay, đảm bảo tàu phản ứng chính xác với các thao tác tay như nghiêng trái/phải hoặc nâng/hạ. Người chơi có thể thực hiện các nhiệm vụ di chuyển đến địa điểm chỉ định, tăng tính đa dạng cho gameplay. Hệ thống này được thiết kế để tái hiện cảm giác điều khiển phương tiện trong không gian, tận dụng tối đa lợi thế của môi trường VR ba chiều.

Hệ thống AI kẻ địch sử dụng **NavMesh Agent** để tạo ra các hành vi thông minh và thử thách. Kẻ địch có khả năng tự động tìm đường đến vị trí người chơi, ghi nhận tọa độ theo thời gian thực, và thực hiện các hành động tấn công như bắn súng hoặc di chuyển chiến thuật. Hệ thống AI được cấu hình để điều chỉnh độ khó dựa trên cấp độ người chơi, đảm bảo trải nghiệm cân bằng cho cả người mới và người chơi có kinh nghiệm. Môi trường trò chơi được xây dựng trên Unity 3D, với các mô hình 3D chi tiết, hiệu ứng ánh sáng động, và âm thanh không gian, tạo ra không gian chiến đấu sống động và thân thiện với người dùng.

### 1.4.3 Đóng góp chính và kết quả đạt được

Tựa game mang lại trải nghiệm nhập vai chân thực thông qua các cơ chế tương tác đa dạng, bao gồm bắn súng, né tránh, chặn đòn, di chuyển nhanh, và điều khiển tàu bay trong không gian ba chiều. Lối chơi chính tập trung vào việc đối quan với kẻ địch, tránh sát thương, và hoàn thành các nhiệm vụ như di chuyển đến các địa điểm chỉ định hoặc tiêu diệt mục tiêu. Hệ thống tính điểm đơn giản được tích hợp, dựa trên các thông số như số lượng kẻ địch tiêu diệt, thời gian hoàn thành nhiệm vụ, và độ chính xác của các hành động, giúp người chơi đánh giá hiệu suất và duy trì động lực tham gia.

Hệ thống cử chỉ tay cho phép người chơi thực hiện các hành động một cách tự nhiên, tăng mức độ hứng thú so với các cơ chế điều khiển truyền thống, đồng thời giảm thời gian làm quen. Hệ thống AI kẻ địch thông minh, kết hợp với cơ chế điều khiển tàu, tạo ra trải nghiệm gameplay phong phú, thử thách khả năng phản xạ và tư duy chiến thuật của người chơi. Trò chơi không chỉ phục vụ mục đích giải trí mà còn đóng góp vào việc phát triển công nghệ tương tác VR, với tiềm năng ứng dụng trong các lĩnh vực như mô phỏng đào tạo quân sự, giao diện điều khiển công nghiệp, hoặc trải nghiệm giáo dục nhập vai.

Hệ thống được thiết kế để dễ dàng tích hợp vào các nền tảng VR phổ biến như **Meta Quest 2**, **Meta Quest 3**, **Pico**, đảm bảo khả năng mở rộng và triển khai thực tế. Kết quả đạt được không chỉ nâng cao chất lượng trải nghiệm người chơi mà còn đặt nền móng cho các nghiên cứu tiếp theo về tương tác cử chỉ tay và AI trong môi trường thực tế ảo, góp phần thúc đẩy đổi mới công nghệ trong ngành công nghiệp game và các lĩnh vực liên quan.

## 1.5 Bố cục đồ án

Phần còn lại của báo cáo đồ án tốt nghiệp này được tổ chức như sau:
* **Chương 2 (Khảo sát và phân tích yêu cầu):** Trình bày về khảo sát yêu cầu và phân tích chức năng của hệ thống. Chương này tập trung vào việc thu thập thông tin từ người chơi tiềm năng thông qua các phương pháp như nghiên cứu các tựa game FPS VR hiện có, nghiên cứu đánh giá của những người dùng tựa game đó.
* **Chương 3 (Công nghệ sử dụng):** Giới thiệu các công nghệ sử dụng trong đồ án. Chương này mô tả các công cụ, thư viện, và nền tảng được áp dụng, bao gồm Unity 3D cho phát triển môi trường 3D, thư viện Gesture Recognition cho nhận diện cử chỉ tay, NavMesh Agent cho hệ thống AI kẻ địch, và các hàm vật lý của Unity cho mô phỏng chuyển động tàu bay. Lý do lựa chọn các công nghệ này sẽ được giải thích, nhấn mạnh tính hiệu quả, khả năng tương thích với VR, và sự phù hợp với mục tiêu đề tài.
* **Chương 4 (Thiết kế trò chơi):** Trình bày về thiết kế, triển khai, và đánh giá hệ thống. Phần này bao gồm kiến trúc tổng thể của trò chơi, thiết kế chi tiết các thành phần như hệ thống cử chỉ tay, điều khiển tàu bay, AI kẻ địch, và môi trường 3D. Quá trình lập trình và tích hợp các thành phần sẽ được mô tả, cùng với các phương pháp tối ưu hóa hiệu suất trên nền tảng VR. Cuối cùng, chương này trình bày quá trình kiểm thử, bao gồm các kịch bản kiểm thử độ chính xác của cử chỉ, hiệu năng AI, và trải nghiệm người chơi, kèm theo kết quả đánh giá để đảm bảo hệ thống đáp ứng các yêu cầu đã đề ra.
* **Chương 5 (Thực nghiệm và đánh giá):** Mô tả các giải pháp và đóng góp nổi bật. Chương này tập trung vào các cải tiến kỹ thuật, như tích hợp cử chỉ tay để thay thế tay cầm truyền thống, hệ thống AI thông minh sử dụng NavMesh Agent, và cơ chế điều khiển tàu bay trong không gian 3D. Những đóng góp này sẽ được phân tích để làm rõ giá trị của đồ án đối với lĩnh vực game VR và tiềm năng ứng dụng trong các ngành khác, như mô phỏng đào tạo hoặc giao diện tương tác.
* **Chương 6 (Kết luận và hướng phát triển):** Tổng kết các nội dung chính của đồ án, đánh giá mức độ hoàn thành mục tiêu ban đầu, và nêu rõ các kết quả đạt được. Đồng thời, chương sẽ thảo luận về những hạn chế của hệ thống, như khả năng say VR hoặc yêu cầu phần cứng. Cuối cùng, các hướng phát triển tiếp theo sẽ được đề xuất, bao gồm cải tiến độ chính xác của cử chỉ tay, mở rộng tính năng multiplayer, và ứng dụng công nghệ vào các lĩnh vực ngoài giải trí.
