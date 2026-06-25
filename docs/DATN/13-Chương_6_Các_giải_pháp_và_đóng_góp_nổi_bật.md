# CHƯƠNG 6. CÁC GIẢI PHÁP VÀ ĐÓNG GÓP NỔI BẬT

---

## 6.1 Giải pháp nhận diện nét vẽ cử chỉ động 3D trong không gian kết hợp thuật toán 2D \$1 Unistroke

### 6.1.1 Đặt vấn đề

Trong ngôn ngữ ký hiệu Mỹ, việc nhận diện các chữ cái tĩnh như A, B, C thường dựa vào việc bắt khớp xương tay ở một thời điểm cố định để so sánh các góc khớp ngón tay. Tuy nhiên, bảng chữ cái ASL chứa hai chữ cái động cực kỳ phức tạp là chữ J và chữ Z, đòi hỏi người học phải thực hiện một chuyển động vẽ nét liên tục trong không gian để mô phỏng hình dạng ký tự. Chuyển động động học này thay đổi liên tục theo thời gian, khiến cho các phương pháp nhận dạng tư thế tay tĩnh hoàn toàn bất lực.

Thách thức lớn nhất khi nhận dạng nét vẽ trong môi trường thực tế ảo là dữ liệu tọa độ 3D thu được từ camera của kính Meta Quest 2 phụ thuộc hoàn toàn vào vị trí đứng, chiều cao và hướng xoay người của học viên trong không gian lớp học ảo. Hơn nữa, nét vẽ thô ban đầu do người học thực hiện thường có mật độ điểm không đều, tốc độ di chuyển tay nhanh chậm khác nhau, và nét vẽ có thể bị nghiêng lệch hoặc co giãn kích thước một cách tự nhiên. Nếu tiến hành đối chiếu trực tiếp các tọa độ 3D này với một mẫu vẽ chuẩn trong thế giới thực, tỷ lệ lỗi sẽ cực kỳ cao và hệ thống gần như không thể nhận diện chính xác.

### 6.1.2 Giải pháp kỹ thuật

Để giải quyết triệt để các rào cản trên, đồ án đã nghiên cứu và phát triển thành công giải pháp chiếu tọa độ cục bộ song song với mặt phẳng Camera kết hợp với quy trình tiền xử lý chuẩn hóa hình học của giải thuật \$1 Unistroke [3].

Đầu tiên, hệ thống thực hiện loại bỏ hoàn toàn sự phụ thuộc vào hướng đứng và vị trí của người học thông qua phép chiếu tọa độ cục bộ. Khi người học giữ tư thế tay nền chuẩn và bắt đầu di chuyển ngón trỏ, lớp VRMagicTrajectory sẽ ghi nhận các tọa độ thế giới 3D của đầu ngón trỏ. Các tọa độ này lập tức được chiếu sang hệ tọa độ 2D cục bộ của Camera người chơi bằng cách sử dụng phép biến đổi ngược ma trận camera (InverseTransformPoint). Phép biến đổi này giúp chuyển đổi các điểm 3D trong không gian thế giới thành các tọa độ 2D phẳng song song với kính nhìn HMD của người học, đảm bảo rằng dù người học đứng ở bất kỳ vị trí nào hay xoay hướng nào trong phòng học ảo thì nét vẽ thu được vẫn luôn đồng nhất dưới góc nhìn của họ.

Sau khi đã có tập điểm 2D phẳng, chuỗi điểm được chuyển sang cho bộ nhận diện thực hiện quy trình chuẩn hóa hình học nghiêm ngặt bao gồm các giai đoạn xử lý toán học liên tục.

#### Đồng bộ hóa số lượng điểm (Resampling)

Tập điểm vẽ thô ban đầu gồm $M$ điểm gốc $P = \{p_0, p_1, \dots, p_{M-1}\}$ có tổng độ dài hình học $L$ được định nghĩa bằng tổng khoảng cách Euclidean giữa các cặp điểm liên tiếp.

$$L = \sum_{i=1}^{M-1} d(p_{i-1}, p_i)$$

Trong đó $d(p_{a}, p_b) = \sqrt{(p_{a,x} - p_{b,x})^2 + (p_{a,y} - p_{b,y})^2}$ là khoảng cách hình học giữa hai điểm. Để triệt tiêu hoàn toàn sự ảnh hưởng của tốc độ vẽ nhanh hay chậm do phản xạ cơ tay của mỗi học viên, thuật toán tiến hành nội suy tuyến tính toàn bộ tập điểm để chuyển đổi chúng thành một chuỗi điểm mới $Q = \{q_0, q_1, \dots, q_{N-1}\}$ gồm đúng $N = 64$ điểm cố định cách đều nhau một khoảng cách hình học $I = L / (N - 1)$. Quá trình này được thực hiện bằng cách duyệt qua các điểm cũ, tính toán khoảng cách tích lũy và chèn các điểm nội suy mới khi khoảng cách tích lũy vượt quá $I$, đảm bảo mật độ điểm phân bổ hoàn toàn đồng đều trên toàn bộ nét vẽ.

#### Khử góc xoay nét vẽ (Rotation to Zero)

Nhằm nhận diện chính xác nét vẽ của học viên kể cả khi họ thực hiện thao tác vẽ bị nghiêng lệch tự nhiên so với phương thẳng đứng, thuật toán tiến hành khử góc xoay của nét vẽ. Đầu tiên, thuật toán xác định trọng tâm hình học $C$ của tập điểm đã đồng bộ $Q$.

$$C = \left(\frac{1}{N}\sum_{i=0}^{N-1} q_{i,x}, \quad \frac{1}{N}\sum_{i=0}^{N-1} q_{i,y}\right)$$

Sau đó, tính toán góc chỉ thị $\theta$ tạo bởi vector hướng nối từ trọng tâm $C$ đến điểm đặt bút đầu tiên $q_0$ so với trục hoành nằm ngang của hệ tọa độ.

$$\theta = \text{atan2}(q_{0,y} - C_y, \quad q_{0,x} - C_x)$$

Cuối cùng, xoay toàn bộ tập điểm $Q$ quanh trọng tâm $C$ một góc bằng $-\theta$ để tạo ra tập điểm mới $R = \{r_0, r_1, \dots, r_{N-1}\}$, đưa hướng chỉ thị của nét vẽ về góc 0 chuẩn nằm ngang.

$$r_{i,x} = (q_{i,x} - C_x)\cos(-\theta) - (q_{i,y} - C_y)\sin(-\theta) + C_x$$
$$r_{i,y} = (q_{i,x} - C_x)\sin(-\theta) + (q_{i,y} - C_y)\cos(-\theta) + C_y$$

#### Khử kích thước nét vẽ (Scaling to Square)

Để chuẩn hóa các nét vẽ có kích thước lớn nhỏ khác nhau do biên độ chuyển động tay của mỗi người học, thuật toán thực hiện co giãn nét vẽ. Trước hết, thuật toán tìm hộp bao hình chữ nhật của nét vẽ sau khi xoay $R$, được xác định bởi các điểm giới hạn cực tiểu và cực đại $(x_{min}, y_{min})$ và $(x_{max}, y_{max})$. Chiều rộng và chiều cao của hộp bao được tính bằng hiệu tọa độ biên, cụ thể là $W = x_{max} - x_{min}$ và $H = y_{max} - y_{min}$. Toàn bộ các điểm trong tập điểm $R$ được co giãn phi tuyến tính để nằm khít trong một hộp bao vuông tiêu chuẩn kích thước $S \times S$ (với $S = 250$ pixel).

$$s_{i,x} = r_{i,x} \times \frac{S}{W}, \quad s_{i,y} = r_{i,y} \times \frac{S}{H}$$

Phép co giãn phi tuyến tính này kéo giãn nét vẽ theo cả hai trục để lấp đầy hộp vuông tiêu chuẩn, giúp đưa mọi nét vẽ về cùng một quy mô so sánh bất kể kích thước thực tế khi vẽ trong không gian ảo.

#### Khử vị trí nét vẽ (Translation to Origin)

Sau khi co giãn về hộp vuông tiêu chuẩn, nét vẽ cần được đưa về gốc tọa độ để loại bỏ hoàn toàn yếu tố vị trí đứng vẽ của người chơi trong phòng học ảo. Thuật toán tính toán trọng tâm hình học mới $C'$ của tập điểm đã co giãn $S$.

$$C' = \left(\frac{1}{N}\sum_{i=0}^{N-1} s_{i,x}, \quad \frac{1}{N}\sum_{i=0}^{N-1} s_{i,y}\right)$$

Sau đó, tiến hành dịch chuyển tịnh tiến toàn bộ tập điểm sao cho trọng tâm $C'$ trùng khớp hoàn toàn với gốc tọa độ hình học $(0, 0)$, tạo ra tập điểm đã chuẩn hóa hoàn chỉnh $T = \{t_0, t_1, \dots, t_{N-1}\}$.

$$t_i = s_i - C'$$

#### So khớp khoảng cách tối ưu (Golden Section Search)

Giai đoạn cuối cùng là đo lường độ tương đồng hình học giữa nét vẽ đã chuẩn hóa của người học $T$ với nét vẽ mẫu tiêu chuẩn $U = \{u_0, u_1, \dots, u_{N-1}\}$ lưu trong thư viện. Khoảng cách đường nét $D(T, U)$ được định nghĩa bằng trung bình cộng khoảng cách Euclide giữa các cặp điểm tương ứng.

$$D(T, U) = \frac{1}{N}\sum_{i=0}^{N-1} d(t_i, u_i)$$

Để xử lý các sai lệch nhỏ về góc xoay tự nhiên của tay người học mà bước Rotate to Zero chưa khử hết, thuật toán áp dụng phương pháp Tìm kiếm Tỷ lệ Vàng (Golden Section Search - GSS). Thuật toán liên tục xoay thử nét vẽ $T$ một góc $\alpha$ trong khoảng giới hạn từ $\theta_1 = -45^\circ$ đến $\theta_2 = 45^\circ$ với hai điểm thử nghiệm $x_1$ và $x_2$ được xác định dựa trên tỷ lệ vàng $\phi = \frac{\sqrt{5}-1}{2} \approx 0.61803$.

$$x_1 = \phi \theta_1 + (1-\phi) \theta_2$$
$$x_2 = (1-\phi) \theta_1 + \phi \theta_2$$

Khoảng tìm kiếm được thu hẹp liên tục cho đến khi chênh lệch góc đạt ngưỡng tối thiểu. Giá trị khoảng cách lệch nhỏ nhất tìm được $D_{min}$ được quy đổi thành điểm số tương đồng theo công thức bên dưới.

$$\text{Score} = 1 - \frac{D_{min}}{0.5 \times \sqrt{S^2 + S^2}}$$

Trong đó, mẫu số biểu thị một nửa độ dài đường chéo của hộp vuông tiêu chuẩn $S \times S$. Điểm số nhận diện dao động từ 0.0 đến 1.0; nếu điểm số vượt quá ngưỡng đỗ cấu hình sẵn (0.80), hệ thống sẽ công nhận nét vẽ chữ cái động tương ứng được thực hiện chính xác.

### 6.1.3 Kết quả đạt được

Việc hiện thực hóa giải pháp chiếu tọa độ cục bộ kết hợp chuẩn hóa \$1 Unistroke đã mang lại kết quả vượt bậc cho đồ án. Hệ thống đạt độ chính xác nhận diện trung bình là **87.3%** đối với hai chữ cái động khó J và Z, hoạt động cực kỳ mượt mà và ổn định mà không bị ảnh hưởng bởi chiều cao hay góc xoay người của học viên.

Bên cạnh đó, giải pháp đã mang lại phản hồi trực quan siêu tốc thời gian thực thông qua việc điều khiển thành phần LineRenderer. Khi người học thực hiện uốn tay thành tư thế chuẩn và vẽ nét, hệ thống hiển thị vệt vẽ phát sáng màu xanh Cyan đối với chữ J và màu hồng Magenta đối với chữ Z. Ngay khi nhận dạng thành công, vệt vẽ lập tức chuyển sang màu xanh lá cây rực rỡ trong đúng 1.0 giây để báo hiệu kết quả hoàn thành chính xác trước khi tự động biến mất, tạo ra một trải nghiệm tương tác trực quan sinh động và lôi cuốn người học.

---

## 6.2 Thiết kế giải pháp sư phạm ứng dụng Hand Tracking và cải tiến EdTech

### 6.2.1 Đặt vấn đề và so sánh với phương pháp truyền thống

Phương pháp tự học ngôn ngữ ký hiệu ASL truyền thống thông qua tài liệu dẹt hai chiều bộc lộ những hạn chế rất lớn về mặt nhận thức và thực hành. Sách ảnh tĩnh hoàn toàn bất lực trong việc mô tả chiều sâu và sự chuyển động liên tục của các khớp ngón tay. Video hướng dẫn phẳng tuy có chuyển động nhưng lại khóa người học ở một góc nhìn camera cố định của người quay, học viên không thể xoay chuyển để quan sát cấu trúc khớp ngón tay ở các góc khuất phía sau. Quan trọng nhất, cả hai phương pháp truyền thống đều hoàn toàn thiếu vắng cơ chế phản hồi sửa lỗi tức thời. Người học tự uốn tay theo mẫu nhưng không thể biết mình đã làm đúng góc độ hay hướng lòng bàn tay chưa; sự sai lệch tích lũy lâu ngày sẽ hình thành thói quen uốn tay sai nghiêm trọng, làm biến đổi hoàn toàn ngữ nghĩa của từ vựng ký hiệu.

Một giải pháp khác là sử dụng công nghệ thực tế ảo VR truyền thống nhưng lạm dụng thiết bị điều khiển vật lý cầm tay. Phương pháp này buộc người học phải ghi nhớ các tổ hợp phím bấm phức tạp trên tay cầm để biểu thị các tư thế tay trong không gian ảo. Việc cầm nắm thiết bị nhựa cứng ngắc làm cản trở hoàn toàn sự chuyển động tự nhiên của bàn tay và triệt tiêu khả năng hình thành trí nhớ cơ bắp – yếu tố sống còn khi học ngôn ngữ ký hiệu, do các ngón tay phải bận giữ và bấm các nút vật lý.

### 6.2.2 Giải pháp cải tiến EdTech và tương tác tay trần

Ứng dụng ASL VR đã giải quyết triệt để các hạn chế của phương pháp truyền thống bằng cách tích hợp công nghệ Hand Tracking kết hợp với các cơ chế sư phạm tương tác và thiết kế gamification dung sai tinh tế.

Đầu tiên, hệ thống tối ưu hóa khả năng trực quan hóa không gian đa chiều và phản hồi sinh học thời gian thực. Người học sử dụng đôi bàn tay trần tự nhiên của mình để thực hành uốn nắn khớp ngón tay trực tiếp, đồng thời tự do di chuyển xung quanh nhân vật giảng viên ảo Kyle hoặc các mẫu tay 3D tĩnh để quan sát cấu trúc cử chỉ từ mọi góc nhìn tùy ý. Dựa trên Thuyết học tập trải nghiệm của David Kolb [2], hệ thống thiết lập một vòng lặp phản hồi sinh học tức thì bằng màu sắc tương phản cao giúp người học ngay lập tức nhận diện chất lượng hành động của mình để tự điều chỉnh cơ tay vật lý chính xác.

Thứ hai, để tránh gây ức chế tâm lý cho người học do các giới hạn vật lý tự nhiên của camera cảm biến trên kính VR, hệ thống tích hợp bộ đệm dung sai Hidden Mistakes. Cơ chế này cho phép người học uốn tay sai lệch nhẹ hoặc bị nhiễu cảm biến tối đa 3 lần trong khoảng trễ từ 1.5 đến 2.0 giây trước khi hệ thống chính thức ghi nhận lỗi phạt thực tế, giúp bao dung các sai số vật lý ngoài ý muốn của thiết bị. Thiết kế dung sai này dựa trên thuyết thất bại có tính xây dựng giúp tạo điều kiện cho học viên tự uốn nắn tay từ những lỗi sai nhỏ để tự rút ra bài học kinh nghiệm sâu sắc.

Thứ ba, ngay sau khi người học bị ghi nhận một lỗi phạt chính thức, hệ thống tự động kích hoạt thời gian vô địch kéo dài từ 1.0 đến 2.0 giây. Trong khoảng thời gian vàng này, hệ thống tạm ngưng nhận diện lỗi sai, cho phép học viên bình tĩnh thả lỏng cơ tay, thoải mái uốn nắn và căn chỉnh lại các ngón tay mà không phải lo sợ bị hệ thống liên tục phạt điểm dồn dập, giúp duy trì trạng thái tập trung sâu.

Cuối cùng, các thiết bị hỗ trợ tự nhiên như bảng điều khiển đeo cổ tay tự động bám theo khớp cổ tay trái/phải giúp người học dễ dàng nghiêng tay xem tiến độ cá nhân mà không cản trở thị giác. Nhân vật giảng viên hướng dẫn Kyle tích hợp máy trạng thái hữu hạn phản hồi biểu cảm động giúp mang lại cảm giác được đồng hành sư phạm kiên nhẫn và thân thiện.

### 6.2.3 Kết quả thực nghiệm đối chứng

Sự cải tiến vượt trội của giải pháp EdTech VR tương tác tay trần so với phương pháp học truyền thống đã được chứng minh một cách khoa học qua dữ liệu thực nghiệm định lượng đối chứng giữa hai nhóm học viên (nhóm học VR standalone và nhóm học video phẳng).

Về hiệu quả tiếp thu kiến thức tức thì, dữ liệu ghi nhận điểm thi trung bình của nhóm học thực tế ảo VR đạt điểm số vượt trội là **25.60/30** ($SD = 2.10$), trong khi nhóm học qua video chỉ đạt **22.20/30** ($SD = 2.45$). Kết quả kiểm định t-test độc lập chứng minh sự khác biệt này có ý nghĩa thống kê cực kỳ rõ rệt ($t = 3.33, p < 0.01$).

Đặc biệt, về khả năng duy trì trí nhớ cơ bắp dài hạn sau 1 tuần không ôn tập và không tiếp xúc với học liệu, nhóm học viên trải nghiệm thực tế ảo VR duy trì được khả năng lưu giữ kiến thức lên tới **84.50%** (điểm trung bình đạt $21.63/30$). Ngược lại, nhóm học viên tự học qua video dẹt bị sụt giảm nghiêm trọng hiệu quả nhớ cơ bắp, chỉ còn đạt **72.80%** (điểm trung bình đạt $16.16/30$). Phép kiểm định t-test độc lập tiếp tục khẳng định lợi thế vượt trội có ý nghĩa thống kê của môi trường thực tế ảo VR ($t = 3.54, p < 0.01$). Kết quả này là minh chứng đắt giá nhất cho thấy việc thực hành tương tác tay trần trực tiếp trong môi trường 3D lập thể đã giúp kiến tạo vùng trí nhớ cơ bắp vận động bền vững và sâu sắc hơn hẳn phương pháp học truyền thống.
